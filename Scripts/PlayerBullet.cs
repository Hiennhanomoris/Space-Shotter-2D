using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float playerBulletSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * playerBulletSpeed );
    }

    //pha huy cac vat the va cham vao no
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.gameObject.CompareTag("background") && !other.gameObject.CompareTag("player"))
        {
            Destroy(other.gameObject);
        }
    }
}
