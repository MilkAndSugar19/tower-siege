using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostUp : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3.33f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<troopMovement>().speed += 0.8f;
    }
}
