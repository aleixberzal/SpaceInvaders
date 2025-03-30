using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb2D;


    public float speed;

  
    // Update is called once per frame
    void Update()
    {
        float horizontal;
        horizontal = Input.GetAxis("Horizontal");
        //Simple vector to move the player only horizontally and we make a Vector3 to be able to use this operand  +=
        Vector3 direction = new Vector2(horizontal, 0f);

        transform.position += direction * speed * Time.deltaTime;
    }
  
}
