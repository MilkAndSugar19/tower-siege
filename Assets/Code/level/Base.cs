using UnityEngine.UI;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int Health;
    public Text healthText;
    [SerializeField] private GameObject LevelLost;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + Health.ToString();
        if(Health <= 0)
        {
            LevelLost.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
}
