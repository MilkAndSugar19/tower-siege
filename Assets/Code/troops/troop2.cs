using UnityEngine;

public class troop2 : MonoBehaviour
{
    [SerializeField] private GameObject boostCircle;
    private bool hasSpawned = false;

    private void Update()
    {
        if(GetComponent<troop1>().troopHealth <= 2.5f && hasSpawned == false)
        {
            Instantiate(boostCircle, transform.position, Quaternion.identity);
            hasSpawned = true;
        }
        
    }
}
