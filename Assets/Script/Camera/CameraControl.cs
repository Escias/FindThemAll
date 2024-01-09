using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;
    [SerializeField]
    private GameObject m_GameScene;

    private bool zoom;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 pointToLook;
    private GameObject hitObject;
    private Vector3 basePosition = new Vector3(0, 30, -25);

    public Vector3 offset;
    public Vector3 targetOffset;
    public float speed;

    private float zoomSpeed = 20f;
    private float minFOV = 15f;
    private float defaultFOV;

    // Start is called before the first frame update
    void Start()
    {
        zoom = false;
        defaultFOV = m_Camera.fieldOfView;
        Debug.Log(defaultFOV);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;

        Ray cameraRay = m_Camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            Zoom();
            HandleZoom();
        }
        RaycastHit hit;
        if (Physics.Raycast(cameraRay, out hit, rayLength))
        {
            hitObject = hit.collider.gameObject;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + moveVelocity * Time.fixedDeltaTime;
        m_Camera.transform.position = newPosition;
    }

    public void Zoom()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            zoom = !zoom;
            if (zoom)
            {
                Vector3 targetPosition = pointToLook + offset;
                m_Camera.fieldOfView = 15f;
                transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
                transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
            }
            else if (!zoom)
            {
                m_Camera.fieldOfView = defaultFOV;
                transform.position = basePosition;
                transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
            }
        }
    }

    public void ZoomOnTarget(GameObject targetGameObject)
    {
        Vector3 targetPosition = targetGameObject.transform.position + targetOffset;
        m_Camera.fieldOfView = 15f;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
        transform.rotation = Quaternion.Euler(new Vector3(10, 0, 0));
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        m_Camera.fieldOfView -= scroll * zoomSpeed;
        m_Camera.fieldOfView = Mathf.Clamp(m_Camera.fieldOfView, minFOV, defaultFOV);
    }

    public GameObject GetHitObject()
    {
        return hitObject;
    }
}
