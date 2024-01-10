using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject m_VictoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowVictoryScreen(bool victory)
    {
        m_VictoryScreen.SetActive(victory);
    }

    public void SetImageVictory(GameObject target)
    {
        SpriteRenderer targetSpriteRenderer = target.GetComponent<SpriteRenderer>();
        Sprite currentSprite = targetSpriteRenderer.sprite;
        GameObject imageScreenVictory = m_VictoryScreen.transform.Find("Screen").gameObject;
        Image image = imageScreenVictory.GetComponent<Image>();
        image.sprite = currentSprite;
    }
}
