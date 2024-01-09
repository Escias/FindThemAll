using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTarget : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;

    private List<GameObject> disabledObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeScreenTarget(GameObject obj)
    {
        string screenTargetFilename = obj.name + "_screen.png";
        ScreenCapture.CaptureScreenshot(screenTargetFilename);
    }

    public void DisableObjectsBetweenCameraAndTargetObject()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("target");
        if (targetObject != null && m_Camera != null)
        {
            Vector3 direction = targetObject.transform.position - m_Camera.transform.position;
            float distance = Vector3.Distance(m_Camera.transform.position, targetObject.transform.position);
            RaycastHit[] hits = Physics.RaycastAll(m_Camera.transform.position, direction, distance);

            foreach (RaycastHit hit in hits)
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject != targetObject && !disabledObjects.Contains(hitObject))
                {
                    disabledObjects.Add(hitObject);
                    hitObject.SetActive(false);
                }
            }
        }
    }

    public void ReactivateDisabledObjects()
    {
        foreach (GameObject obj in disabledObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        disabledObjects.Clear();
    }
}
