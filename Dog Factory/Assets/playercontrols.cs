using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrols : MonoBehaviour
{
    public GameObject projectile;
    float kickCoolDown = 0;
    float kickCoolDownDuration = 0.5f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
    }
}
