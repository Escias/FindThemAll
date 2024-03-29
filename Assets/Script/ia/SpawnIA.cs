using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIA : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabIA;
    [SerializeField]
    private GameObject parentObject;

    [SerializeField]
    private int posY;

    public int nbIA;


    // Start is called before the first frame update
    void Start()
    {
        spawnIA();
    }


    private void spawnIA()
    {
         for(int i = 0; i != nbIA; i++)
        {
            Vector3 pos = Random.insideUnitCircle * 55;
            pos.z = pos.y;
            pos.y = posY;
            GameObject newObject = Instantiate(prefabIA, pos+ transform.position, Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform, false);
        }
    }
}
