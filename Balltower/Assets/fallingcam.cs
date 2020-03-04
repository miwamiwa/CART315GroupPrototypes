using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingcam : MonoBehaviour
{
    public bool falling = false;
    public GameObject arrow;
    public GameObject trigger;
    float kickCoolDown = 0;
    public float kickCoolDownDuration = 1f;
    public GameObject projectile;


    void Update()
    {
        // speed up camera follow during fall
        if(falling)
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.001f;
        // move arrow
        arrow.transform.LookAt(trigger.transform, -arrow.transform.up);
        arrow.transform.Rotate(new Vector3(-90, 0, 0));

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
            }
        }
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
