using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int addedTime = 10;
    [SerializeField] AudioClip itemSound;

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.CompareTag("Player")){
            GameManager.Instance.time += addedTime;
            AudioSource.PlayClipAtPoint(itemSound, transform.position);
            Destroy(gameObject, 0.1f);
        }
    }
}