using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [SerializeField]
    private Image[] images;


    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < images.Length; i++)
        {
            Debug.Log(images[i].name + "_screen.png");
            if (new DirectoryInfo(images[i].name + "_screen.png").Exists)
            {
                Debug.Log("oui");
            }
            else
            {
                Debug.Log("non");
            } 
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
