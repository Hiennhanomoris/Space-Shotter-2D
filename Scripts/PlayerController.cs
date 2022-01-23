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
    [SerializeField] private float moveSpeed;
    new Rigidbody2D rigidbody;
    public Boundary boundary;
    public Transform firePoint;
    public GameObject bullet;
    [SerializeField] float fireRate;
    private float nextFire;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
}
