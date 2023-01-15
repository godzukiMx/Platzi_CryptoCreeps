using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject checkpointPrefab;
    [SerializeField] int checkpointSpawnDelay = 13;
    [SerializeField] float spawnRadius = 7;
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
    }

    IEnumerator SpawnCheckpointRoutine(){
        while (true){
            yield return new WaitForSeconds(checkpointSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius; 
            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
    }
}