using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class BackMenu : MonoBehaviour
{

    private bool isCommandPanelOpen = false;

    [SerializeField]
    private Image image;

    

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void command()
    {
        if (isCommandPanelOpen)
        {
            image.enabled = false;
            isCommandPanelOpen = false;
        }
        else
        {
            
            image.enabled = true;
            isCommandPanelOpen = true;
        }
    }
}
