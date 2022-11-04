using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTile : MonoBehaviour
{
    public GameObject heldTurret, previewTurret;
    [System.NonSerialized] public GameObject hologram;
    [System.NonSerialized] public int thisPrice;

    private Vector2 mousePos;

    private void Awake()
    {

        thisPrice = heldTurret.GetComponent<Rotation>().turretPrice;
        if(previewTurret != null)
            Instantiate(previewTurret, transform);
    }

    private void Update()
    {
        if(hologram != null)// Draw hologram
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            hologram.transform.position = mousePos;
        }
        if (Input.GetMouseButtonDown(1)) //Cancel purchase
        {
            if(hologram != null)
            {
                gameObject.GetComponentInParent<Shop>().money += thisPrice;
                GetComponentInParent<Shop>().selectedTurret = null;
                Destroy(hologram);
                hologram = null;
            }
        }


    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponentInParent<Shop>().money >= thisPrice && GetComponentInParent<Shop>().selectedTurret == null)
            {
                hologram = (GameObject)Instantiate(previewTurret, transform);
                gameObject.GetComponentInParent<Shop>().money -= thisPrice;
                GetComponentInParent<Shop>().selectedTurret = heldTurret;
            }
        }
    }

}
