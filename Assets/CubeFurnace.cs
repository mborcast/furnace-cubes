using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFurnace : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other) 
    {
        CubeValue cubeValue = other.GetComponent<CubeValue>();
        this.scoreManager.increaseScore(cubeValue.getCurrentValue());

        Destroy(other.gameObject);
    }
}
