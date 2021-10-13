﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    //Parameters
    public float restPosition = 0F;
    public float pressedPosition = 45F;
    public float flipperStrength = 10F;
    public float flipperDamper = 1F;

    public string inputButtonName = "LeftPaddle";
    private new HingeJoint hingeJoint;
    JointSpring JointSpring;

    float flipTime = 0f;

    Matrix matrix;


    // Start is called before the first frame update
    void Start() {
        hingeJoint = GetComponent<HingeJoint>();

        JointSpring = new JointSpring();

        hingeJoint.useSpring = true;
        JointLimits limits = hingeJoint.limits;
        limits.min = restPosition;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        limits.max = pressedPosition;
        hingeJoint.limits = limits;
        hingeJoint.useLimits = true;
        hingeJoint.limits = limits;
        JointSpring.spring = flipperStrength;
        JointSpring.damper = flipperDamper;

    }

    // Update is called once per frame
    void Update() {
        if (flipTime > 0) {
            JointSpring.targetPosition = pressedPosition;
            flipTime -= Time.deltaTime;
        }

        else if (Input.GetKey(inputButtonName)) {
            activate();
        }

        else {
            JointSpring.targetPosition = restPosition;
        }

        hingeJoint.spring = JointSpring;
    }

    public void activate() {
        flipTime = 1f;
    }
}
