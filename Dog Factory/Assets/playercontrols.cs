﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrols : MonoBehaviour
{
    public GameObject projectile;
    float kickCoolDown = 0;
    float kickCoolDownDuration = 0.1f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (Time.time > kickCoolDown)
            {

                float distance = 1.7f;
                Vector3 spawnpos = transform.forward * distance + transform.position + new Vector3(0f,1f,0f);

                GameObject newBall = Instantiate(projectile, spawnpos, transform.rotation);
                Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
                rigidbody.velocity = transform.forward * 10f;
                kickCoolDown = Time.time + kickCoolDownDuration;

                anim.Play("t-pose");
            }
        }
    }
}
