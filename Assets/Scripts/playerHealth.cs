using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerHealth : MonoBehaviour
{
    //We instantiante the player's lifes and if the player has no lifes it's destroyed. Whereas if the player has lifes left we get one. 
    public int playerLifes = 3;
    invaders invaderScript;
    public void TakeDamage()
    {
        playerLifes--;
        Debug.Log("Vidas restantes: " + playerLifes);

        if (playerLifes <= 0)
        {
            Destroy(gameObject);
            Debug.Log("El jugador ha muerto");
        }

    }
    //Function to kill instantly the player whenever is needed (when the aliens reach the buildings height for example)
    public void playerDeath()
    {
        playerLifes = 0;
        Destroy(gameObject);
    }
}
