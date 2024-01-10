using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiments : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Color emissiveColor = Color.yellow;
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", (emissiveColor* Random.Range(1f, 4f)*Time.deltaTime));
        
    }
}
