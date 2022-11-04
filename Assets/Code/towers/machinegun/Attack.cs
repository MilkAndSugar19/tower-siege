using UnityEngine;

public class Attack : MonoBehaviour
{
    public float turretDamage, turretAttackSpeed;
    public GameObject turretParticle;

    void Start()
    {
        InvokeRepeating("AttackAttempt", turretAttackSpeed, turretAttackSpeed);
    }

    void AttackAttempt()
    {
        GameObject turretObjective = GetComponent<Rotation>().lockedEnemy;
        if(turretObjective != null)
        {
            troop1 troopReference = turretObjective.GetComponent<troop1>();
            gameObject.GetComponent<AudioSource>().Play();
            troopReference.troopHealth -= turretDamage;
            Instantiate(turretParticle, turretObjective.transform.position, Quaternion.identity);
        }
    }
}
