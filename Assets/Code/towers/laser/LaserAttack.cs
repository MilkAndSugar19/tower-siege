using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    public float turretDamage, turretAttackSpeed;
    public GameObject turretParticle;
    float turretRange;

    void Start()
    {
        InvokeRepeating("AttackAttempt", turretAttackSpeed, turretAttackSpeed);
        turretRange = GetComponent<Rotation>().turretRange;
    }

    void AttackAttempt()
    {
        GameObject turretObjective = GetComponent<Rotation>().lockedEnemy;
        if (turretObjective != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Instantiate(turretParticle, transform.position, transform.rotation);
        }
    }   
}
