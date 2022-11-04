using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantkill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float i = 1f;
    void Awake()
    {
        Destroy(gameObject, i);   
    }
}
