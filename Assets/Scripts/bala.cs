using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public float speed = 10f;
    public string tagCollision = "Destruible";
    public int cont = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.up * speed;


    }
 
    // Update is called once per frame
    
        

     

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagCollision)
        {
            //We destroy the bullet once it touches anything with the assigned tag
            Debug.Log("Objeto tocado");
            Destroy(gameObject);
        }
    }
}
