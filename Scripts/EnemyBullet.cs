using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float enemyBulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        this.transform.Translate(Vector2.down * enemyBulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("player"))
        {
            PlayerController.Instance.TakeHealth(10);
        }
    }
}
