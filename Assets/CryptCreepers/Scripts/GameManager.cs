using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int difficulty = 1;
    public int time = 30;
    public bool gameOver = false;
    [SerializeField] int score;
    private AudioManager gameMusic;

    public int Score{
        get => score;
        set {
            score = value;
            UIManager.Instance.UpdateUIScore(score);
            if(score % 1000 == 0){
                difficulty++;
            }
        }
    }

        public int uiTime{
        get => time;
        set {
            time = value;
            UIManager.Instance.UpdateUITime(time);
        }
    }

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    private void Start()
    {
        gameMusic = FindObjectOfType<AudioManager>();
        Time.timeScale = 1;
        StartCoroutine(CountdownRoutine());
    }

    // Game over when the time comes down to 0
    IEnumerator CountdownRoutine(){
        while (uiTime > 0){
            gameMusic.GameMusic();
            yield return new WaitForSeconds(1);
            uiTime--;
        }

        gameOver = true;
        Time.timeScale = 0;
        gameMusic.GameOverMusic();
        UIManager.Instance.ShowGameOverScreen();
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Game");
    }
}
