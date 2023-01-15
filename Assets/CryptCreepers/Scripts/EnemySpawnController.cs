using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [Range(1, 10)][SerializeField]float spawnRate = 1;
    [SerializeField] GameObject[] enemyPrefab;
    
     // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpanwnNewEnemy());
    }

    IEnumerator SpanwnNewEnemy(){
        while (true)
        {
            yield return new WaitForSeconds(1/spawnRate);
            float random = Random.Range(0.0f, 1.0f);

            if(random < GameManager.Instance.difficulty * 0.1f){
                Instantiate(enemyPrefab[0]);
            }
            else{
                Instantiate(enemyPrefab[1]);
            }
                         
        } 
    }
}
