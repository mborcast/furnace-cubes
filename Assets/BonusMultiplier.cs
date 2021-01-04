using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMultiplier : MonoBehaviour
{
    public float multiplier;

    private void OnTriggerEnter(Collider other) 
    {
        CubeValue cubeValue = other.GetComponent<CubeValue>();
        cubeValue.applyMultiplier(this.multiplier);
    }
}
