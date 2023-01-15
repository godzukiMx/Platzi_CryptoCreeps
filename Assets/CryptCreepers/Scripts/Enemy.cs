using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 1;
    [SerializeField] int health = 1;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }
    
    [HideInInspector] public void TakeDamage() {
        health --;
        if(health <= 0){
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
            Destroy(gameObject);
    }
}
