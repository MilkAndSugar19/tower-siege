using UnityEngine;

public class troop4 : MonoBehaviour
{
    [SerializeField] private GameObject HealAura;
    void Start()
    {
        InvokeRepeating("HealNearbyTroops", 5f, 5f);
    }
    private void HealNearbyTroops()
    {
        Instantiate(HealAura, transform.position, Quaternion.identity);
    }
}
