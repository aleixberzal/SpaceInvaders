using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NON FUNCIONAL
public class invader : MonoBehaviour
{
    //If an invader touches the end of bounds, all of them change direction

    public int speed;
    private Vector2 direction = Vector2.right;

    private void Update()
    {
        transform.position = speed * Time.deltaTime * direction; 
    }


}
