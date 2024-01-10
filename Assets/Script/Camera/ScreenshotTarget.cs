using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenshotTarget : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;

    CameraControl cameraControl;
    WinScreen winScreen;
    GameObject targetGameObject;

    private List<GameObject> disabledObjects = new List<GameObject>();
    private bool isOnTarget;

    // Start is called before the first frame update
    void Start()
    {
        cameraControl = GetComponent<CameraControl>();
        winScreen = GetComponent<WinScreen>();
        isOnTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeScreenTarget(GameObject obj)
    {
        StartCoroutine(TakeScreenshotCoroutine(obj.name + "_screen.png", obj));
    }

    private IEnumerator TakeScreenshotCoroutine(string filename, GameObject target)
    {
        if (target)
        {
            isOnTarget = true;
            DisableObjectsBetweenCameraAndTargetObject();
            yield return new WaitForEndOfFrame();
            ScreenCapture.CaptureScreenshot(filename);
            ReactivateDisabledObjects();
            winScreen.SetImageVictory(target);
            winScreen.ShowVictoryScreen(true);
            yield return new WaitForSeconds(3f);
            cameraControl.Unzoom();
            isOnTarget = false;
            yield return new WaitForSeconds(2f);
            winScreen.ShowVictoryScreen(false);
        }
        else
        {
            Debug.Log("target is null");
        }
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

    public bool GetIsOnTarget()
    {
        return isOnTarget;
    }
}
