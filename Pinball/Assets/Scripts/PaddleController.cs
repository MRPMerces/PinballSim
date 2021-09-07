using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    //Parameters
    public float restPosition = 0F;
    public float pressedPosition = 45F;
    public float flipperStrength = 10F;
    public float flipperDamper = 1F;

    public string inputButtonName = "LeftPaddle";

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

        JointLimits limits = hingeJoint.limits;
        limits.min = restPosition;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        limits.max = pressedPosition;
        hingeJoint.limits = limits;
        hingeJoint.useLimits = true;
        hingeJoint.limits = limits;
    }
}
