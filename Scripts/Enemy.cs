using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    public Transform enemyFirePoint;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] float fireRate;
    private int direct = 1;
    private float nextFire;

    //chi so
    public int max_health;
    public int current_health;
    public int damage;
    public int point;

    public virtual void Awake() 
    {
        current_health = max_health;    
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        move();
        Fire();
    }

    public virtual void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(enemyBullet, enemyFirePoint.position, Quaternion.identity);

            // thay doi direct lam enemy chuyen huong
            direct *= -1;
        }
    }

    public virtual void move()
    {
        //di chuiyen theo Oy
        this.transform.Translate(Vector2.down * enemySpeed);

        //di chuyen theo Ox
        this.transform.Translate(Vector2.right * direct * 0.08f);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("player_bullet"))
        {
            Destroy(other.gameObject);
        } 
        if(other.gameObject.CompareTag("player"))
        {
            PlayerController.Instance.TakeHealth(10);
        }   
    }

    public virtual void TakeHealth(int amount)
    {
        if(this.current_health > amount)
        {
            this.current_health -= amount;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
