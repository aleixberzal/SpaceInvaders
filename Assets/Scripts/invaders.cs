using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invaders : MonoBehaviour
{
    /*1. For iteration to spawn a 3 rows of 7 columns of invaders. 
      2. Depending on the row the invader is, it will be one sprite or another. 
      */
    private Vector2 spawnLocator;
    public int xpos,ypos;
    public GameObject redInvader, blueInvader, yellowInvader;
    public short alienNum = 7;
    private short rows = 3;
    public float xDistance;
    public float yDistance;

    private void Start()
    {
        Spawn(); 
    }

    private void Spawn()
    {

        for (int i = 0; i < alienNum; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector2 newPosition = new Vector2(xpos+i * xDistance, ypos+j*yDistance);
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

    //To make the invaders fire we instantiate a firepoint randomly in a position every x (rnd) seconds and make them fire a bullet downsides 



}
