using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    public GameObject ball;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start() {
        startingPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("r")) {
            resetBall();
        }
    }

    void OnCollisionEnter(Collision _other) {
        if (_other.gameObject == ball) {
            resetBall();
        }
    }

    Action<OutOfBounds> cbOutOfBounds;

    public void RegisterOutOfBounds(Action<OutOfBounds> callbackfunc) {
        cbOutOfBounds += callbackfunc;
    }

    public void UnregisterOutOfBounds(Action<OutOfBounds> callbackfunc) {
        cbOutOfBounds -= callbackfunc;
    }

    void resetBall() {
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.position = startingPos;
        cbOutOfBounds(this);
    }
}
