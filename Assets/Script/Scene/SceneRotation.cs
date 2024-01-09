using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRotation : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            rotationAmount = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotationAmount = rotationSpeed * Time.deltaTime;
        }
        transform.Rotate(0, rotationAmount, 0, Space.World);
    }
}
