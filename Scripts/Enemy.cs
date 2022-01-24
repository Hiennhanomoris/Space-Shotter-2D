using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        this.transform.Translate(Vector2.up * enemySpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("background") && !other.gameObject.CompareTag("enemyBullet"))
        {
            Destroy(other.gameObject);
        }    
    }
}
