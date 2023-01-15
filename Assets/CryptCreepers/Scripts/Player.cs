using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    float v;
    Vector3 moveDirection;
    Vector2 facingDirection;
    bool gunLoaded = true;
    [SerializeField] float speed = 3;
    [SerializeField] Transform aim;
    [SerializeField] Camera camara;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] float fireRate = 1;
    [SerializeField] int playerHealth = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PLayer movement
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection * Time.deltaTime * speed;

        // Aim movement
        facingDirection = camara.ScreenToWorldPoint(Input.mousePosition) - (transform.position / 2);
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        // Shoot projectiles
        if(Input.GetMouseButton(0) && gunLoaded) {
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
        }


    }

    IEnumerator ReloadGun(){
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }

    public void TakeDamage (){
        playerHealth --;
    }
}
