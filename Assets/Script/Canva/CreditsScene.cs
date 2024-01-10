using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ExitScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExitScene()
    {
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene("Menu");
    }
}
