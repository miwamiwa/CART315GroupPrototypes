using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doggoscript : MonoBehaviour
{

    string state = "idle";
    int timer = 0;

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
                    switchState("getready");
                }
                

                break;

            case "getready": if (timer > 50) switchState("charge"); break;

            case "charge":


                transform.position += chargeDir.normalized * 1f;

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
}
