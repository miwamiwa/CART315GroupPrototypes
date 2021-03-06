﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothefollow : MonoBehaviour
{
    // cred
    // https://answers.unity.com/questions/1154053/smoothly-rotate-camera.html

    //Insert your final position & rotation here as an empty Transform
    public Transform target;
    public float movementTime = 1;
    public float rotationSpeed = 0.1f;

    Vector3 refPos;
    Vector3 refRot;

    void Update()
    {
        if (!target)
            return;
        //Interpolate Position
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref refPos, movementTime);
        //Interpolate Rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
    }
}
