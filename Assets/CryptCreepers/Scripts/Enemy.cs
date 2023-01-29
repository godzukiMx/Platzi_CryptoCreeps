using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    [SerializeField] float speed = 1;
    [SerializeField] int health = 1;
    [SerializeField] int scorePoints = 100;
    [SerializeField] AudioClip impactSound;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0,spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }

    void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }
    
    [HideInInspector] public void TakeDamage() {
        health --;
        AudioSource.PlayClipAtPoint(impactSound, transform.position);

        if(health <= 0){
            GameManager.Instance.Score += scorePoints;
            KillEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
        collision.GetComponent<Player>().TakeDamage();
        }
    }

    private void KillEnemy(){
            Destroy(gameObject, 0.1f);
    }
}
