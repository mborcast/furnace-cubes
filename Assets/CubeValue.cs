using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeValue : MonoBehaviour
{
    [SerializeField]
    private int _value;

    private void Start() 
    {
        this._value = 1;   
    }

    public void applyMultiplier(float multiplier) 
    {
        this._value = (int)(this._value * multiplier);
    }

    public int getCurrentValue() 
    {
        return this._value;
    }
}

