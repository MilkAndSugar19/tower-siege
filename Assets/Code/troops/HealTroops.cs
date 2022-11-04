using UnityEngine;

public class HealTroops : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<troop1>().troopHealth += 5;
        if (collision.GetComponent<troop1>().troopHealth > collision.GetComponent<troop1>().troopMaxHealth)
        {
            collision.GetComponent<troop1>().troopHealth = collision.GetComponent<troop1>().troopMaxHealth;
        }
    }
}
