using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroWave : MonoBehaviour
{
    public float turretDamage, turretAttackSpeed;
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

            if (turretObjective.GetComponent<ElectroDOT>() != null)
                turretObjective.GetComponent<ElectroDOT>().i = 0;

            else if (turretObjective.GetComponent<ElectroDOT>() == null)
                turretObjective.AddComponent<ElectroDOT>();

            turretObjective.GetComponent<troop1>().troopHealth -= turretDamage;
        }
    }
}
