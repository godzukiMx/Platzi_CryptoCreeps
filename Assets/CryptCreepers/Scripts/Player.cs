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
    public float speed = 3;
    [SerializeField] Transform aim;
    [SerializeField] Camera camara;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] float fireRate = 1;
    bool powerShotEnable;
    [SerializeField] int playerHealth = 20;
    bool invulnerable;
    [SerializeField] float invulnerableTime = 3;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer spriteRenderer;

    public int Health{
        get => playerHealth;
        set{
            playerHealth = value;
            UIManager.Instance.UpdateUIHealth(Health);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateUIHealth(Health);
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
            Transform bulletClone = Instantiate(bulletPrefab, transform.position, targetRotation);

            if (powerShotEnable){
                bulletClone.GetComponent<Bullet>().powerShot = true;
            }
            
            StartCoroutine(ReloadGun());
        }

        anim.SetFloat("Speed", moveDirection.magnitude);
        if (aim.position.x > transform.position.x){
            spriteRenderer.flipX = true;
        }else if(aim.position.x < transform.position.x){
                spriteRenderer.flipX = false;
        }

    }

    IEnumerator ReloadGun(){
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }

    public void TakeDamage (){
        if(invulnerable){
            return;
        }
        
        Health--;
        invulnerable = true;
        StartCoroutine(MakeVulnerableAgain());

        if(Health <= 0){
            GameManager.Instance.gameOver = true;
            UIManager.Instance.ShowGameOverScreen();
        }
    }

    IEnumerator MakeVulnerableAgain(){
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp")){
            switch (collision.GetComponent<PowerUp>().powerType){
                case PowerUp.PowerUpType.FireRateIncrease:
                fireRate++;
                break;
                case PowerUp.PowerUpType.PowerShot:
                powerShotEnable = true;
                break;
            }
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
