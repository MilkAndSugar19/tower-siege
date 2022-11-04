using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFadeout : MonoBehaviour
{
    public float fadeoutTime;
    private void Start()
    {
        DestroyObjectDelayed();
    }
    void DestroyObjectDelayed()
    {
        Destroy(gameObject, fadeoutTime);
    }

}
