using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int difficulty = 1;
    public int time = 30;

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    // Game over when the time comes down to 0
    IEnumerator CountdownRoutine(){
        while (time > 0){
            yield return new WaitForSeconds(1);
            time --;
        }
    }
}
