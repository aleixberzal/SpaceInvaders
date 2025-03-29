using UnityEngine;

public class invaders : MonoBehaviour
{
    /*1. For iteration to spawn a 3 rows of 7 columns of invaders. 
      2. Depending on the row the invader is, it will be one sprite or another. 
      */
    private Vector2 spawnLocator;
    public int xpos, ypos;
    public GameObject redInvader, blueInvader, yellowInvader;
    public short alienNum = 7;
    private short rows = 3;
    public float xDistance;
    public float yDistance;

    //Movement variables
    public float baseSpeed = 1f;
    public float maxSpeed = 3f;
    public float stepDownDistance = 0.5f;
    private bool movingRight = true;
    public float leftBoundary, rightBoundary;
    private int totalInvaders;
    private GameObject invadersParent;

    // Firing variables
    public GameObject invaderLaserPrefab; 
    private float nextFireTime;
    public float minFireDelay = 0.3f;    
    public float maxFireDelay = 2f;     

    private void Start()
    {
        Spawn();
        LimitController();
        totalInvaders = invadersParent.transform.childCount;
        nextFireTime = Time.time + maxFireDelay;
    }

    private void Update()
    {
        moveInvaders();
        TryFireLaser();
    }

    private void Spawn()
    {
        invadersParent = new GameObject("InvadersContainer");

        for (int i = 0; i < alienNum; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector2 newPosition = new Vector2(xpos + i * xDistance, ypos + j * yDistance);
                GameObject newInvader = null;

                if (j == 1)
                {
                    newInvader = Instantiate(redInvader, newPosition, Quaternion.identity);
                }
                else if (j == 2)
                {
                    newInvader = Instantiate(blueInvader, newPosition, Quaternion.identity);
                }
                else
                {
                    newInvader = Instantiate(yellowInvader, newPosition, Quaternion.identity);
                }

                newInvader.transform.SetParent(invadersParent.transform);
            }
        }
    }

    private void LimitController()
    {
        leftBoundary = -2.3f;
        rightBoundary = 2.3f;
    }

    private void moveInvaders()
    {
        if (invadersParent == null) return;
        /*Invaders speed increases 10% for each invader killed*/
        float currentSpeed = Mathf.Min(
            baseSpeed + (totalInvaders - invadersParent.transform.childCount) * 0.1f,
            maxSpeed
        );

        // Horizontal movement
        if (movingRight)
        {
            invadersParent.transform.position += Vector3.right * currentSpeed * Time.deltaTime;
        }
        else
        {
            invadersParent.transform.position += Vector3.left * currentSpeed * Time.deltaTime;
        }

        if (invadersParent.transform.position.x >= rightBoundary ||
            invadersParent.transform.position.x <= leftBoundary)
        {
            movingRight = !movingRight;
            invadersParent.transform.position += Vector3.down * stepDownDistance;
        }
    }

    private void TryFireLaser()
    {
        // Si el cooldown ha terminado, un invasor dispara
        if (Time.time > nextFireTime && invadersParent != null && invadersParent.transform.childCount > 0)
        {
            FireFromRandomInvader();
            nextFireTime = Time.time + 3f; // Establece el próximo disparo en 3 segundos
        }
    }


    private void FireFromRandomInvader()
    {
        //We initiate a random varibale that gets the number of children there is, and chooses one of them to fire a laser bullet
        int childCount = invadersParent.transform.childCount;

        int randomIndex = Random.Range(0, childCount);
        Transform randomInvader = invadersParent.transform.GetChild(randomIndex);

        Instantiate(invaderLaserPrefab, randomInvader.position, Quaternion.identity);
    }
}