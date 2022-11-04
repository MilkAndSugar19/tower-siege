using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroDOT : MonoBehaviour
{
    private float baseSpeed, slowedSpeed;
    [System.NonSerialized] public int i = 0;
    private void Start()
    {
        baseSpeed = GetComponent<troopMovement>().speed;
        slowedSpeed = baseSpeed * 0.44f;
        Invoke("DOT", 0f);
    }

    private void DOT()
    {
        GetComponent<troopMovement>().speed = slowedSpeed;
        GetComponent<troop1>().troopHealth -= GetComponent<troop1>().troopHealth * 0.2f;

        GetComponent<SpriteRenderer>().color = new Vector4(0, 255, 255, 255);

        if(i < 5)
        {
            Invoke("DOT", 1f);
        }
        if(i == 5)
        {
            GetComponent<troopMovement>().speed = baseSpeed;
            GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 255);
            Destroy(gameObject.GetComponent<ElectroDOT>());
        }
        i++;
    }
}
