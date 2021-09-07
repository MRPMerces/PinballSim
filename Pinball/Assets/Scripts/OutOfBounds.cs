using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    Transform ball;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start() {
        startingPos = ball.position;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision _other) {

        if (_other.gameObject.tag == "Ball") {
            Debug.Log("hello");
            _other.rigidbody.velocity = Vector3.zero;
            _other.transform.position = startingPos;
        }

    }
}
