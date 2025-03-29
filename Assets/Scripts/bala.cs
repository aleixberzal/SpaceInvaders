using UnityEngine;

public class bala : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 10f;
    public string tagCollision;
    public bool isEnemyBullet; 
  

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if (isEnemyBullet)
        {
            rb2D.velocity = -transform.up * speed;
        }
        else
        {
            rb2D.velocity = transform.up * speed; 
        }
    }

  private void OnTriggerEnter2D(Collider2D collision)
{
    if (isEnemyBullet)
    {
            if (collision.tag == "Player")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    else
    {
            if (collision.tag == "Destruible")

            {
                Destroy(gameObject);
            }
    }
}
}