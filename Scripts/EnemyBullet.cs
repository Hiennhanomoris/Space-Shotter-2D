using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
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
        this.transform.Translate(Vector2.down);
    }

    public void OntriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("background") && !other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
