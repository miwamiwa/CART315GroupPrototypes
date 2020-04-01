using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doggoscript : MonoBehaviour
{

    string state = "idle";
    int timer = 0;

    public float chargeSpeed = 0.1f;

    GameObject targetBall;
    Vector3 chargeDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        switch (state)
        {
            case "idle":

                GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
                bool[] inRange = new bool[balls.Length];
                int inRangeCount = 0;

                for (int i = 0; i < balls.Length; i++)
                {
                    Vector3 ballPos = balls[i].transform.position;
                    Vector3 dist = currentPos - ballPos;


                    if (dist.magnitude < 10)
                    {
                        inRange[i] = true;
                        inRangeCount++;
                    }
                    else inRange[i] = false;
                }

                if (inRangeCount > 0)
                {
                    int randomPick = Random.Range(0, inRangeCount);
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
        }
        

        timer++;
    }

    void switchState(string newstate)
    {
        Debug.Log(newstate);
        state = newstate;
        timer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == "charge")
        {
            if (collision.gameObject.tag == "Ball")
            {
                switchState("idle");
            }

            if (collision.gameObject.tag == "Wall")
            {
                switchState("idle");
            }
        }
        
    }
}
