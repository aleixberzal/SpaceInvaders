using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    //In seconds
    public float coolDown = 0.7f;
    private float lastFiredBullet;
    public GameObject balaPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    
   

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Z) && Time.time > lastFiredBullet + coolDown)
        {
            //Cooldown application

            Shoot();
            lastFiredBullet = Time.time;
             
        }
    }
    void Shoot()
    {
        GameObject bullet= Instantiate(balaPrefab, firePoint.position, transform.rotation);
        Debug.Log("POW");
        Destroy(bullet, 3);
    }
}
