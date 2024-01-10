using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Canvas;
    [SerializeField]
    private GameObject m_Resume;

    private List<GameObject> childrenWithTrophyTag;
    private List<string> lines;

    // Start is called before the first frame update
    void Start()
    {
        childrenWithTrophyTag = GetTrophy(m_Canvas);
        CreateFolderIfNotExists(Application.persistentDataPath + "/save");
    }

    // Update is called once per frame
    void Update()
    {
        SetOpacity();
        CheckTrophyFile(Application.persistentDataPath + "/save/trophy.txt");
    }

    public void Resume()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Play()
    {
        if (File.Exists(Application.persistentDataPath + "/save/trophy.txt"))
        {
            DeleteFile(Application.persistentDataPath + "/save/trophy.txt");
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static void CreateFolderIfNotExists(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    void SetOpacity()
    {
        ReadFileTrophy();
        foreach (GameObject trophy in childrenWithTrophyTag)
        {
            float opacityValue = 0.5f;
            Image image = trophy.GetComponent<Image>();
            Debug.Log(image.sprite.name);
            if (image != null)
            {
                if (lines.Contains(image.sprite.name))
                {
                    opacityValue = 1f;
                }
                Color color = image.color;
                color.a = Mathf.Clamp(opacityValue, 0, 1);
                image.color = color;
            }
            else
            {
                Debug.LogError("Image component not found.");
            }
        }
    }

    List<GameObject> GetTrophy(GameObject parent)
    {
        List<GameObject> taggedChildren = new List<GameObject>();

        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.tag == "trophy")
            {
                taggedChildren.Add(child.gameObject);
            }
        }

        return taggedChildren;
    }

    void ReadFileTrophy()
    {
        lines = new List<string>();

        if (!File.Exists(Application.persistentDataPath + "/save/trophy.txt"))
        {
            Console.WriteLine("File not found: " + Application.persistentDataPath + "/save/trophy.txt");
            return;
        }

        using (StreamReader sr = new StreamReader(Application.persistentDataPath + "/save/trophy.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
    }

    void CheckTrophyFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            m_Resume.SetActive(true);
        }
        else
        {
            m_Resume.SetActive(false);
        }
    }

    void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
