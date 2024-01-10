using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;

    CameraControl cameraControl;
    ScreenshotTarget screenshotTarget;
    GameObject targetGameObject;
    //GameObject trophyObjects;

    // Start is called before the first frame update
    void Start()
    {
        cameraControl = GetComponent<CameraControl>();
        screenshotTarget = GetComponent<ScreenshotTarget>();
        //List<GameObject> childrenWithTrophyTag = GetChildrenWithTag(parentObject, "trophy");
    }

    // Update is called once per frame
    void Update()
    {
        targetGameObject = cameraControl.GetHitObject();
        if (Input.GetMouseButtonDown(0) && !screenshotTarget.GetIsOnTarget())
        {

            if (targetGameObject.tag == "target")
            {
                cameraControl.ZoomOnTarget(targetGameObject);
                screenshotTarget.TakeScreenTarget(targetGameObject);
            }
        }
    }

    /*List<GameObject> GetChildrenWithTag(GameObject parent, string tag)
    {
        List<GameObject> taggedChildren = new List<GameObject>();

        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.tag == tag)
            {
                taggedChildren.Add(child.gameObject);
            }
        }

        return taggedChildren;
    }*/
}
