using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTranslate : MonoBehaviour
{
    public float speed;
    private Vector3 _velocity;

    private Rigidbody _rb;

    private void Start() 
    {
        this._rb = this.GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        this._velocity = Vector3.right * this.speed;
    }

    private void FixedUpdate() 
    {
        this._rb.MovePosition(this.transform.position + this._velocity * Time.deltaTime);
    }
}
