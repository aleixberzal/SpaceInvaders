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
    public float xDistance = 0.5f;
    public float yDistance = 0.5f;

    // Movement variables
    public float baseSpeed = 0.5f;
    public float maxSpeed = 1.5f;
    public float moveDownDistance = 0.3f;
    private bool movingRight = true;
    public float leftBoundary, rightBoundary;
    public float bottomBoundary;
    private int totalInvaders;
    private GameObject invadersParent;

    // Firing variables
    public GameObject invaderLaserPrefab;
    private float nextFireTime;
    public float delay = 1f;

    private void Start()
    {
        CalculateScreenBoundaries();
        Spawn();
        //We will create a parent that groups all the invaders as children, to make the movement simpler
        totalInvaders = invadersParent.transform.childCount;
        //We delay the first laser to give the player a head start
        nextFireTime = Time.time + delay;
    }

    private void Update()
    {
        moveInvaders();
        TryFireLaser();
    }

    private void CalculateScreenBoundaries()
    {
        //To indicate the invaders when to move right, we set boundaries based on the camera, as  it is an orthopedic 2d fixed camera and wont move all game
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;

        //We will leave a 10% margin on the sides 
        leftBoundary = -cameraWidth * 0.9f;
        rightBoundary = cameraWidth * 0.9f;

        //We set the bottom boundary to this height for the invaders to kill the player when they reach the buildings
        bottomBoundary = -cameraHeight * 0.4f;
    }

    private void Spawn()
    {
        //Simple iteration to spawn the invaders with a container that acts as a parent
        invadersParent = new GameObject("InvadersContainer");

        for (int i = 0; i < alienNum; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                //We add the distance we want between our spaceships
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

    private void moveInvaders()
    {
        //In case there are not more left, we do not apply this logic
        if (invadersParent == null || invadersParent.transform.childCount == 0) return;

        //We increase the invaders speed 10% for each of them that is killed
        float currentSpeed = Mathf.Min(
            baseSpeed + (totalInvaders - invadersParent.transform.childCount) * 0.1f,
            maxSpeed
        );

        if (movingRight)
        {
            invadersParent.transform.position += Vector3.right * currentSpeed * Time.deltaTime;
        }
        else
        {
            invadersParent.transform.position += Vector3.left * currentSpeed * Time.deltaTime;
        }

        //We find all the invaders that are the furthest to the right, left, and down
        float currentLeftBoundary = float.MaxValue;
        float currentRightBoundary = float.MinValue;
        float currentLowestPoint = float.MaxValue;

        //To every invader inside the parent, we change directions
        foreach (Transform invader in invadersParent.transform)
        {
            Vector3 position = invader.position;

            if (position.x < currentLeftBoundary)
                currentLeftBoundary = position.x;
            if (position.x > currentRightBoundary)
                currentRightBoundary = position.x;
            if (position.y < currentLowestPoint)
                currentLowestPoint = position.y;
        }

        if (currentLowestPoint <= bottomBoundary)
        {
            //In case the lowest point passes through the down bound, we kill the player setting its lifes to null
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerHealth health = player.GetComponent<playerHealth>();
                if (health != null)
                {
                    health.playerDeath();
                }
            }
        }

        // Checking horizontal bounds, and moving down invaders through its parent in case they reach the left or right corner
        if ((movingRight && currentRightBoundary >= rightBoundary) ||
            (!movingRight && currentLeftBoundary <= leftBoundary))
        {
            movingRight = !movingRight;
            invadersParent.transform.position += Vector3.down * moveDownDistance;
        }
    }

    private void TryFireLaser()
    {
        //If the cooldown has passed we fire from a random invader and add our next cooldown
        if (Time.time > nextFireTime && invadersParent != null && invadersParent.transform.childCount > 0)
        {
            FireFromRandomInvader();
            nextFireTime = Time.time + delay;
        }
    }

    private void FireFromRandomInvader()
    {
        //We count up all the children that are left (invaders), and get a random number and with that number we get the child and insantiate a laser prefab from a random invader
        int childCount = invadersParent.transform.childCount;
        int randomIndex = Random.Range(0, childCount);
        Transform randomInvader = invadersParent.transform.GetChild(randomIndex);
        Instantiate(invaderLaserPrefab, randomInvader.position, Quaternion.identity);
    }

 
}