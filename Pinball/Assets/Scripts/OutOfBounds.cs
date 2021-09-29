using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    public Transform ball;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start() {
        startingPos = ball.position;
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKey("r"))
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.transform.position = startingPos;
        }

   
    }

    void OnCollisionEnter(Collision _other) {

        if (_other.gameObject.tag == "Ball") {
            _other.rigidbody.velocity = Vector3.zero;
            _other.transform.position = startingPos;
        }

    }
}
