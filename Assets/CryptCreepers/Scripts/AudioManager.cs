using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioClip titleTrack;
    [SerializeField] AudioClip gameTrack;
    [SerializeField] AudioClip gameOverTrack;

    public void TitleMusic()
    {
        ChangeBGM(titleTrack);
        BGM.loop = true;
    }

    public void GameMusic()
    {
        ChangeBGM(gameTrack);
        BGM.loop = true;
    }

    public void GameOverMusic()
    {
        ChangeBGM(gameOverTrack);
        BGM.loop = false;
    }

    private void ChangeBGM(AudioClip newTrack)
    {
        BGM.Stop();
        BGM.clip = newTrack;
        BGM.Play();
    }
}
