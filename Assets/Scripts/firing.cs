using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{

    public GameObject balaPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    
   

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }   
    }
    void Shoot()
    {
        Instantiate(balaPrefab, firePoint.position, transform.rotation);
        Debug.Log("POW");
    }
}
