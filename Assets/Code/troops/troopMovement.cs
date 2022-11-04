using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troopMovement : MonoBehaviour
{
    public float speed = 2f;

    private Transform target;
    private int index = 0;

    void Start()
    {
        target = controller.points[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, target.position) <= 0.05f)
            NextWaypoint();
    }

    void NextWaypoint()
    {
        if(index >= controller.points.Length - 1)
        {
            GameObject.Find("base").GetComponent<Base>().Health -= GetComponent<troop1>().troopDamage;
            Destroy(gameObject);
            return;
        }

        index++;
        target = controller.points[index];
    }
}
