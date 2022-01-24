using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asteroid : MonoBehaviour
{
    [SerializeField] private float asteroidSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();     
    }

    public void move()
    {
        this.transform.Translate(Vector2.down * asteroidSpeed);  
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.gameObject.CompareTag("background"))
        {
            Destroy(other.gameObject);
        }
    }
}
