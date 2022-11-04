using UnityEngine;

public class TankExplosion : MonoBehaviour
{
    [SerializeField] private GameObject turretReference;

    private void Awake()
    {
        Invoke("SelfDisable", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<troop1>().troopHealth -= turretReference.GetComponent<TankAttack>().turretDamage;
    }

    void SelfDisable()
    {
        CircleCollider2D c = gameObject.GetComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        c.enabled = false;
    }
}
