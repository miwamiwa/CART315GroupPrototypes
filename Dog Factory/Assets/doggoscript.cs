using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doggoscript : MonoBehaviour
{

    string state = "idle";
    int timer = 0;

    float chargeSpeed = 0.1f;
    int blindEye = -1;

    GameObject targetBall;
    Vector3 chargeDir;
    Vector3 strayDir;
    GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {
         balls = GameObject.FindGameObjectsWithTag("Ball");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        switch (state)
        {
            case "idle":

                
                bool[] inRange = new bool[balls.Length];
                int inRangeCount = 0;

                for (int i = 0; i < balls.Length; i++)
                {
                    Vector3 ballPos = balls[i].transform.position;
                    Vector3 dist = currentPos - ballPos;


                    if (dist.magnitude < 10)
                    {
                        if (i != blindEye || balls[i].GetComponent<Rigidbody>().velocity.magnitude > 1f)
                        {
                            inRange[i] = true;
                            inRangeCount++;
                        }
                        
                    }
                    else inRange[i] = false;
                }

                if (inRangeCount > 0)
                {
                    int randomPick = Random.Range(0, inRangeCount);
                    blindEye = randomPick;
                    targetBall = balls[randomPick];
                    chargeDir = targetBall.transform.position - transform.position;
                    chargeDir = new Vector3(chargeDir.x,0,chargeDir.z);
                    switchState("getready");
                }
                

                break;

            case "getready": if (timer > 50)
                {
                    switchState("charge");
                    transform.LookAt(targetBall.transform.position, Vector3.up);
                }
                break;

            case "charge":


                transform.position += chargeDir.normalized * chargeSpeed;

                break;

            case "wait":

                if (timer > 100) switchState("idle");
                break;

            case "stray":

                transform.position += strayDir * 0.01f;
                if (timer > 100) switchState("wait");
                break;
        }
        

        timer++;
    }

    void switchState(string newstate)
    {
        Debug.Log(newstate);
        state = newstate;
        timer = 0;
    }

 

    private void OnCollisionStay(Collision collision)
    {
        if (state == "charge" || state == "stray")
        {
            if (collision.gameObject.tag == "Ball")
            {
                switchState("wait");
            }

            if (collision.gameObject.tag == "Wall")
            {
                switchState("stray");
                blindEye = -1;
                strayDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            }
        }

    }
}
