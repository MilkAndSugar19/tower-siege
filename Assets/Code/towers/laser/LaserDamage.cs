using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public GameObject reference;
    float dmg;
    private void Start()
    {
        dmg = reference.GetComponent<LaserAttack>().turretDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<troop1>().troopHealth -= dmg;
    }
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.025f);
        if (gameObject.GetComponent<SpriteRenderer>().color.a <= 0)
            Destroy(gameObject);
    }

}
