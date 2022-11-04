using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public float turretDamage, turretAttackSpeed;

    [SerializeField] private GameObject tankExplosive;
    [SerializeField] private GameObject lightParticle;
    [SerializeField] private Transform[] barrel;
    [SerializeField] private GameObject lastEnemyPos;
    [SerializeField] private AudioClip sound;

    private GameObject turretObjective;
    
    private troop1 troopReference;

    private int i = 0;

    

    void Start()
    {
        InvokeRepeating("AttackAttempt", turretAttackSpeed, turretAttackSpeed);
    }

    void AttackAttempt()
    {
        turretObjective = GetComponent<Rotation>().lockedEnemy;
        if (turretObjective != null)
        {
            troopReference = turretObjective.GetComponent<troop1>();

            Instantiate(lightParticle, barrel[i]);

            AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0));

            if (i < 2)
            {
                troopReference.GetComponent<troop1>().troopHealth -= turretDamage;
            }
            else
                Instantiate(tankExplosive, troopReference.transform.position, Quaternion.identity);

            i++;
            i %= 3;
        }
    }
}
