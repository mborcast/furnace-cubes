using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 5f;
    public float waitTime = 1f;
    public float maxElevation = 4f;

    private int _direction = 1;

    private Vector3 _startPosition;
    private Vector3 _velocity;

    private Rigidbody _rb;

    private void Start() {
        this._rb = this.GetComponent<Rigidbody>();
        this._startPosition = this.transform.position;

        StartCoroutine(moveElevator());
    }

    private void FixedUpdate() {
        this._rb.MovePosition(this.transform.position + this._velocity * Time.deltaTime);
    }

    IEnumerator moveElevator()
    {
        yield return new WaitForSeconds(1f);
        
        while (true) {
            this._velocity = Vector3.up * this.speed * this._direction;

            if (this.hasArrivedToDestination()) {
                this.stopElevator();
                this.clampPosition();
                this.changeDirection();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    private bool hasArrivedToDestination() 
    {
        var currentElevation = this.getCurrentElevation();

        if (this.isGoingUp()) {
            return currentElevation >= this.maxElevation;
        }
        return currentElevation <= 0;
    }
    
    private bool isGoingUp() 
    {
        return this._direction > 0;
    }

    private float getCurrentElevation() 
    {
        return this.transform.position.y - this._startPosition.y;
    }

    private void stopElevator() 
    {
        this._velocity = Vector3.zero;
    }

    private void clampPosition() 
    {
        var currentPosition = this.transform.position;

        if (this.isGoingUp()) {
            currentPosition.y = this._startPosition.y + this.maxElevation;
        }
        else {
            currentPosition.y = this._startPosition.y;
        }
        this.transform.position = currentPosition;
    }

    private void changeDirection() 
    {
        this._direction *= -1;
    }
}
