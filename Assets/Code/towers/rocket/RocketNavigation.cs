using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketNavigation : MonoBehaviour
{
    private float damage;
    private Vector3 enemyPos;
    public ParticleSystem explosion;

    private bool exploded = false;

    // Start is called before the first frame update
    void Awake()
    {
        damage = GetComponentInParent<RocketAttack>().turretDamage;
        enemyPos = GetComponentInParent<RocketAttack>().lastEnemyPos.transform.position;
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        float ms = 9 * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, enemyPos, ms);
        if(transform.position == enemyPos && exploded == false)
        {
            Explode();
        }
    }

    void Explode()
    {
        exploded = true;
        CircleCollider2D explosionRadius = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        explosionRadius.isTrigger = true;
        explosionRadius.radius = 0.8f;

        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject, 0.04f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<troop1>().troopHealth -= damage;
    }
}
