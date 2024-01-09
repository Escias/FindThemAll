using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryCanvaScript : MonoBehaviour
{
    [SerializeField]
    private Image imageConteneur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void display(Sprite image)
    {
        gameObject.SetActive(true);
        imageConteneur.sprite = image;
        Invoke(nameof(unDisplay), 2f);
    }

    private void unDisplay()
    {
        gameObject.SetActive(false);
    }

}
