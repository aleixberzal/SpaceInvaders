using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnee : MonoBehaviour
{
    public GameObject red_prefab;
    public GameObject yellow_prefab;
    public GameObject green_prefab;

    public Vector3 red_position = new Vector3(-7f, 3f, 0f);
    public Vector3 yellow_position = new Vector3(-7f, 1f, 0f);
    public Vector3 green_position = new Vector3(-7f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    void spawn()
    {
         Instantiate(red_prefab, red_position, transform.rotation);
         Instantiate(yellow_prefab, yellow_position, transform.rotation);
         Instantiate(green_prefab, green_position, transform.rotation);
    }
}
