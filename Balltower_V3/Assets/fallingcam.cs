﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fallingcam : MonoBehaviour
{
    public bool falling = false;
    public GameObject arrow;
    public GameObject trigger;
    float kickCoolDown = 0;
    public float kickCoolDownDuration = 1f;
    public GameObject projectile;
    public Animator anim;
    public bool arrowActivated = false;
    float arrowOff = 0f;
    public bool isOnBall = false;
    public float arrowTime = 5f; // time during which arrow is visible
  
    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (isOnBall)
        {

            if (
                Input.GetKeyDown("a")
                || Input.GetKeyDown("d")
                || Input.GetKeyDown("s")
                || Input.GetKeyDown("w")
                || Input.GetKeyDown(KeyCode.Space)
                ) gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        // speed up camera follow during fall
        if(falling)
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.001f;

        if (arrowActivated)
        {
           // Debug.Log("yo");
            // move arrow
            arrow.transform.LookAt(trigger.transform, -arrow.transform.up);
            arrow.transform.Rotate(new Vector3(-90, 0, 0));

            if (Time.time > arrowOff)
            {
                arrow.GetComponent<MeshRenderer>().enabled = false;
                arrowActivated = false;
            }
        }
       

        if (Input.GetKeyDown("o"))
        {
            if (Time.time > kickCoolDown)
            {
                
                float distance = 2f;
                Vector3 spawnpos = transform.forward * distance + transform.position;

                GameObject newBall = Instantiate(projectile, spawnpos, transform.rotation);
                Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
                rigidbody.velocity = transform.forward * 10f;
                kickCoolDown = Time.time + kickCoolDownDuration;
               
                anim.Play("t-pose");
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("intro");
        }
       
    }

    public void triggerArrow()
    {
        arrowActivated = true;
        arrowOff = Time.time + arrowTime;
        arrow.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            
            // reset camera upon hitting the ground
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.24f;
            falling = false;
        }
    }
}
