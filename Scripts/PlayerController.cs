using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private PlayerStatus player_status;
    [SerializeField] private float moveSpeed;
    new Rigidbody2D rigidbody;
    public Boundary boundary;
    public Transform firePoint;
    public GameObject bullet;
    [SerializeField] float fireRate;
    private float nextFire;

    void Awake()
    {
        //for singleton 
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        rigidbody = GetComponent<Rigidbody2D>();
        player_status.current_health = player_status.max_health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
        Fire();
    }

    void Fire()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }

    void HandleMovement()
    {
        // lay input tu axis san co cua unity de dieu khien player di chuyen
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        rigidbody.velocity = movement * moveSpeed;

        //han che khong gian di chuyen cho player
        rigidbody.position = new Vector2
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax)
        );
    }

    //xu ly va cham
    void OnTriggerEnter2D(Collider2D other) 
    {
        // khi cham vao cac vat the asteroid, enemy
        if(!other.gameObject.CompareTag("background") && !other.gameObject.CompareTag("player_bullet"))
        {
            if(other.gameObject.CompareTag("enemy_bullet"))
            {
                Destroy(other.gameObject);
            }
            else
            {
                if(other.gameObject.CompareTag("enemy1"))
                {
                    if(player_status.damage >= other.gameObject.GetComponent<Enemy>().current_health)
                    {
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        other.gameObject.GetComponent<Enemy>().current_health -= player_status.damage;
                    }
                }
            }
        }    
    }

    public void TakeHealth(int amount)
    {
        if(player_status.current_health > amount)
        {
            player_status.current_health -= amount;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public int GetDamage()
    {
        return player_status.damage;
    }
}
