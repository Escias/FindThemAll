using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;

    CameraControl cameraControl;
    ScreenshotTarget screenshotTarget;

    private GameObject targetGameObject;
    private Coroutine c_Screenshot;

    // Start is called before the first frame update
    void Start()
    {
        cameraControl = GetComponent<CameraControl>();
        screenshotTarget = GetComponent<ScreenshotTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cameraControl.GetHitObject().tag == "target")
            {
                cameraControl.ZoomOnTarget(cameraControl.GetHitObject());
                screenshotTarget.TakeScreenTarget(cameraControl.GetHitObject());
            }
        }
    }
}
