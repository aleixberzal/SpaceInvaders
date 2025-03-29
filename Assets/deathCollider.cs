using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bala")
        {
            Debug.Log("Objeto tocado por la bala");
            Destroy(gameObject);
        }
    }
}
