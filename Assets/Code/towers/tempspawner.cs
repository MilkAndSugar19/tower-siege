using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempspawner : MonoBehaviour
{
    public GameObject troop, troop2;
    public float timeToSpawn = 0.5f;

    private int i = 0;
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("Spawner", 0.01f, timeToSpawn);
    }

    void Spawner()
    {
        if (i % 8 == 0)
            Instantiate(troop2, new Vector3(-7.5f, -5.5f), transform.rotation);
        else
            Instantiate(troop, new Vector3(-7.5f, -5.5f), transform.rotation);
        i++;
        i %= 10;
    }
}
