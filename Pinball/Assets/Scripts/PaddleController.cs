using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    //Parameters
    float restPosition = 0F;
    float pressedPosition = 45F;
    float flipperStrength = 10F;
    float flipperDamper = 1F;

    string inputButtonName = "LeftPaddle";

    HingeJoint hingeJoint;

    // Start is called before the first frame update
    void Start() {
        hingeJoint = GetComponent<HingeJoint>();

        hingeJoint.useSpring = true;
    }

    // Update is called once per frame
    void Update() {
        JointSpring JointSpring = new JointSpring();

        JointSpring.spring = flipperStrength;
        JointSpring.damper = flipperDamper;

        if (Input.GetButton(inputButtonName)) {
            JointSpring.targetPosition = pressedPosition;
        }

        else {
            JointSpring.targetPosition = restPosition;
        }

        hingeJoint.spring = JointSpring;
        hingeJoint.useLimits = true;
        hingeJoint.limits.min = restPosition;
        hingeJoint.limits.max = pressedPosition;
    }
}
