using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnee : MonoBehaviour
{
    /*1. For iteration to spawn a 3 rows of 7 columns of invaders. 
      2. Depending on the row the invader is, it will be one sprite or another. 
      */
    private Vector2 spawnLocator;
    public int xpos,ypos;
    public GameObject redInvader, blueInvader, yellowInvader;
    private short rows = 7;
    private short columns = 3;
    public float xDistance;
    public float yDistance;

    private void Start()
    {
        Spawn(); 
    }

    private void Spawn()
    {

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 newPosition = new Vector3(xpos+i * xDistance, ypos+j*yDistance, 0.0f);
                if (j == 1)
                {
                    Instantiate(redInvader, newPosition, Quaternion.identity);

                }else if(j == 2)
                {
                    Instantiate(blueInvader, newPosition, Quaternion.identity);

                }
                else
                {
                    Instantiate(yellowInvader, newPosition, Quaternion.identity);

                }
            }
        }
    }
}
