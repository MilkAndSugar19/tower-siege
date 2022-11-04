using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [System.NonSerialized] public List<GameObject> enemiesInRange = new List<GameObject>();
    [System.NonSerialized] public GameObject lockedEnemy;
    [System.NonSerialized] public float distance;
    public float turretRange;
    

    public int turretPrice;

    private void Awake()
    {
        CircleCollider2D sc = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        sc.isTrigger = true;
        sc.radius = turretRange;
        distance = turretRange + 1;
    }


    // Update is called once per frame
    void Update()
    {   
        if (lockedEnemy == null || distance > turretRange)
        {
            int t = 0;
            distance = turretRange + 1;
            foreach (GameObject enemy in enemiesInRange)
            {
                if (distance > Vector3.Distance(enemiesInRange[t].transform.position, transform.position))
                {
                    distance = Vector3.Distance(enemiesInRange[t].transform.position, transform.position);
                    lockedEnemy = enemiesInRange[t];
                }
                t++;
            }
        }
        if(distance <= turretRange && lockedEnemy != null)
        {
            var dir = lockedEnemy.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if(lockedEnemy != null)
            distance = Vector3.Distance(lockedEnemy.transform.position, transform.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemiesInRange.Add(collision.gameObject);      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemiesInRange.Remove(collision.gameObject);
        if (lockedEnemy == collision.gameObject)
            lockedEnemy = null;

    }
}
