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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        move();
        Fire();
    }

    void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(enemyBullet, enemyFirePoint.position, Quaternion.identity);

            // thay doi direct lam enemy chuyen huong
            direct *= -1;
        }
    }

    public void move()
    {
        //di chuiyen theo Oy
        this.transform.Translate(Vector2.down * enemySpeed);

        //di chuyen theo Ox
        this.transform.Translate(Vector2.right * direct * 0.08f);
    }

    public void OnTriggerEnter2D(Collider2D other)
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
}
