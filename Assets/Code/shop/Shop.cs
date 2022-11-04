using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public GameObject selectedTurret;

    public Text moneyText;

    public int money = 150;

    public GameObject[] turretsForSale;
    public int[] turretPrices;

    private bool isShown = false;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < turretsForSale.Length; i++)
        {
            turretPrices[i] = turretsForSale[i].GetComponent<Rotation>().turretPrice;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isShown == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                isShown = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                isShown = false;
            }
        }
    }

    public GameObject GetTurretToBuild()
    {
        GameObject temp = selectedTurret;
        selectedTurret = null;
        return temp;
    }

    private void Update()
    {
        moneyText.text = "Money: " + money.ToString();
    }
}
