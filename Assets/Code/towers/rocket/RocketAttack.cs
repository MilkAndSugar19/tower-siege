using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAttack : MonoBehaviour
{
    public float turretAttackSpeed;
    public float turretDamage;

    [System.NonSerialized] public GameObject lastEnemyPos;
    private int i = 0;

    public GameObject rocketPrefab;
    public GameObject[] spawners;


    private void Start()
    {
        InvokeRepeating("AttackAttempt", turretAttackSpeed, turretAttackSpeed);
    }

    private void AttackAttempt()
    {
        lastEnemyPos = GetComponent<Rotation>().lockedEnemy;
        if(lastEnemyPos != null)
        {
            i++;
            i %= 2;
            Instantiate(rocketPrefab, spawners[i].transform);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
