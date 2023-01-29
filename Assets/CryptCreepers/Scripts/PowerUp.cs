using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] AudioClip itemSound;
    
    public enum PowerUpType {
        FireRateIncrease, 
        PowerShot
    }

    public PowerUpType powerType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
        AudioSource.PlayClipAtPoint(itemSound, transform.position);
        }
    }
}
