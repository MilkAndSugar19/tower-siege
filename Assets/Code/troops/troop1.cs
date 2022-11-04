using UnityEngine;

public class troop1 : MonoBehaviour
{

    public float troopHealth, troopMaxHealth;
    public int troopDamage, troopValue;

    private void Awake()
    {
        troopMaxHealth = troopHealth;
    }
    void Update()
    {
        if(troopHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject.FindGameObjectWithTag("shop").GetComponent<Shop>().money += troopValue;
        Destroy(gameObject);
    }
}
