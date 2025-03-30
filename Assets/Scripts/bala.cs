using UnityEngine;

public class bala : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 10f;
    public bool isEnemyBullet;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //Ternary to declare which rigidBody is impacting the boxCollider. If it is the enemy's or not 
        rb2D.velocity = (isEnemyBullet ? -transform.up : transform.up) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Depending on the tag the collision is impacting we:
        if (isEnemyBullet && collision.CompareTag("Player"))
        {
            playerHealth playerHealth = collision.GetComponent<playerHealth>();
            //In case there are missing lifes, take one out
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
                collision.transform.position = new Vector3(0f, -4.5f, 0f);
            }
            //If lifes are null, we destroy the player
            Destroy(gameObject);
        }
        else if (!isEnemyBullet && collision.CompareTag("Destruible"))
        {
            //If the tag is from the enemies, we destroy the bullet prefab and the enemy
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }else if(collision.CompareTag("Building")){
            //In case it is the building, it becomes smaller with each hit
            collision.transform.localScale *= 0.9f;
            Destroy(gameObject);
        }
    }
}
