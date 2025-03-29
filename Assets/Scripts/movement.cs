using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float movimiento = 0f;

    public float speed;

  
    // Update is called once per frame
    void Update()
    {
        float horizontal;
        horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector2(horizontal, 0f);

        transform.position += direction * speed * Time.deltaTime;
    }
  
}
