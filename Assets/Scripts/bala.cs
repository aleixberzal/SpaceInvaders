using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 10f;
    public string tagCollision = "Destruible";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
 
    // Update is called once per frame
    
        

     

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagCollision)
        {
            Destroy(gameObject);
        }
    }
}
