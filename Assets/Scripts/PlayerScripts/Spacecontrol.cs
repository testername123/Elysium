﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Spacecontrol : MonoBehaviour
{
    public float MoveForce = 5, brakeforcemlp = -5;


    Rigidbody2D myBody;
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 moveVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal") * MoveForce * 10),
        (CrossPlatformInputManager.GetAxis("Vertical"))
        * MoveForce * 10);
        myBody.AddForce(moveVec);

    }
}
