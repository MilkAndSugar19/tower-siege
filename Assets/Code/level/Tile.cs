using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor = new Vector4(255, 253, 95, 255);
    public Color baseColor;
    private SpriteRenderer rend;

    private GameObject turretOnTop;
    private int storedPrice;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        baseColor = rend.color;
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (turretOnTop != null)
            {
                return;
            }
            if (Shop.instance.GetComponent<Shop>().selectedTurret != null)
            {
                GameObject turretToBuild = Shop.instance.GetTurretToBuild();
                this.turretOnTop = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);

                for (int i = 0; i < GameObject.FindGameObjectWithTag("shop").transform.childCount; i++)
                {
                    Destroy(GameObject.FindGameObjectWithTag("shop").transform.GetChild(i).GetComponent<ShopTile>().hologram);
                    GameObject.FindGameObjectWithTag("shop").transform.GetChild(i).GetComponent<ShopTile>().hologram = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(turretOnTop != null)
            {
                GameObject.Find("shop_arrow").GetComponent<Shop>().money += turretOnTop.GetComponent<Rotation>().turretPrice / 2;
                Destroy(turretOnTop);
                turretOnTop = null;
            }
        }
    }

    private void OnMouseEnter()
    {
        rend.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.color = baseColor;
    }
}
