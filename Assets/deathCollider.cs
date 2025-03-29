using UnityEngine;

public class deathCollider : MonoBehaviour

{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Bala")) 
        {
            if (gameObject.tag != ("Player"))
            {
                Debug.Log("Enemy destroyed by player laser");
                Destroy(gameObject);
            }
        }
        else if (collision.tag == ("Enemylaser")) 
        {
            if (gameObject.tag == ("Player"))
            {
                Debug.Log("Player destroyed by enemy laser, lifes: " );
                Destroy(gameObject);
            }
        }
    }
}