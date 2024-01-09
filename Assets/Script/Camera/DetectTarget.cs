using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;

    CameraControl cameraControl;
    GameObject targetGameObject;

    // Start is called before the first frame update
    void Start()
    {
        cameraControl = GetComponent<CameraControl>();
        if (cameraControl == null)
        {
            Debug.LogError("CameraControl component not found on the same GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && m_Camera.fieldOfView == cameraControl.GetDefaultFov())
        {
            cameraControl.Zoom(true);
            GetVisibleObjects();
        }
    }

    void GetVisibleObjects()
    {
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (IsObjectVisible(m_Camera, obj))
            {
                if (obj.tag == "target")
                {
                    Debug.Log("FIND");
                    TakeScreenTarget(obj);
                }
            }
        }
    }

    bool IsObjectVisible(Camera camera, GameObject obj)
    {
        Vector3 pointOnScreen = camera.WorldToViewportPoint(obj.transform.position);
        RaycastHit hit;
        Vector3 direction = obj.transform.position - camera.transform.position;

        if (pointOnScreen.z < 0)
        {
            return false;
        }

        if ((pointOnScreen.x < 0) || (pointOnScreen.x > 1) || (pointOnScreen.y < 0) || (pointOnScreen.y > 1))
        {
            return false;
        }

        if (Physics.Raycast(camera.transform.position, direction, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject != obj)
            {
                return false;
            }
        }
        return true;
    }

    void TakeScreenTarget(GameObject obj)
    {
        string screenTargetFilename = obj.name + "_screen.png";
        ScreenCapture.CaptureScreenshot(screenTargetFilename);
        Debug.Log("Screenshot taken and saved as " + screenTargetFilename);
        Debug.Log(Application.persistentDataPath);
    }
}
