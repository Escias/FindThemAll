using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upAndDown : MonoBehaviour
{
    [SerializeField]
    private int start;

    [SerializeField]
    private int end;

    [SerializeField]
    private GameObject manege;

    public float speed;


    private bool isUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manege.transform.position.y > start)
        {
            isUp = false;
        }

        if (manege.transform.position.y < end)
        {
            isUp = true;
        }


        if (isUp == false)
        {
            manege.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            manege.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        
    }
}
