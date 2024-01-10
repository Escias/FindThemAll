using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource[] audios;

    private AudioSource actualMusic;
    // Start is called before the first frame update
    void Start()
    {
        playMusic();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!actualMusic.isPlaying)
        {
            playMusic();
        }
    }

    private void playMusic()
    {
        int random = Random.Range(0, 2);
        audios = GetComponents<AudioSource>();
        actualMusic = audios[random];
        actualMusic.Play();
    }
}
