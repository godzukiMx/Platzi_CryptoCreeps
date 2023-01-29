using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private AudioManager titleMusic;

    // Start is called before the first frame update
    void Start()
    {
        titleMusic = FindObjectOfType<AudioManager>();
        titleMusic.TitleMusic();
        Time.timeScale = 0;
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
    }
}
