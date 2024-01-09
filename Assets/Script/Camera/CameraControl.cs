using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;
    [SerializeField]
    private GameObject m_BasePositionCamera;
    [SerializeField]
    private GameObject m_GameScene;

    private bool zoom;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 pointToLook;

    public Vector3 offset;
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
            Zoom(false);
        }
        HandleZoom();
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + moveVelocity * Time.fixedDeltaTime;
        m_Camera.transform.position = newPosition;
    }

    public void Zoom(bool getTarget)
    {
        if (Input.GetMouseButtonDown(1) || (getTarget && Input.GetMouseButtonDown(0))) 
        {
            zoom = !zoom;
            float fov = m_Camera.fieldOfView;
            if (fov != defaultFOV && !getTarget)
            {
                zoom = false;
            }
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
                transform.position = new Vector3(0, 30, -25);
                transform.rotation = Quaternion.Euler(new Vector3(60, 0, 0));
            }
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        m_Camera.fieldOfView -= scroll * zoomSpeed;
        m_Camera.fieldOfView = Mathf.Clamp(m_Camera.fieldOfView, minFOV, defaultFOV);
    }

    public float GetDefaultFov()
    {
        return defaultFOV;
    }
}
