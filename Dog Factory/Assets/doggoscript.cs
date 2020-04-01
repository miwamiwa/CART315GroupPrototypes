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
    GameObject targetPeppe;
    Vector3 chargeDir;
    Vector3 strayDir;
    GameObject[] balls;
    Vector3 center;

    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
         balls = GameObject.FindGameObjectsWithTag("Ball");
        center = GameObject.Find("center").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        switch (state)
        {
            case "idle":

                GameObject[] pepperonis = GameObject.FindGameObjectsWithTag("Peppe");
                int peppeInRangeCount = 0;
                bool[] ballInRange = new bool[balls.Length];
                bool[] peppeInRange = new bool[pepperonis.Length];
                int inRangeCount = 0;

                for (int i = 0; i < pepperonis.Length; i++)
                {
                    Vector3 peppePos = pepperonis[i].transform.position;
                    Vector3 dist = currentPos - peppePos;
                  //  Debug.Log(dist.magnitude);

                    if (dist.magnitude < 10)
                    {
                        peppeInRange[i] = true;
                            peppeInRangeCount++;
                    }
                    else peppeInRange[i] = false;
                }

                if (peppeInRangeCount > 0)
                {
                   // Debug.Log(peppeInRangeCount);
                        int randomPick = Random.Range(0, peppeInRangeCount);
                  //  Debug.Log(randomPick);
                       // blindEye = randomPick;

                        int count = 0;

                        for (int i = 0; i < pepperonis.Length; i++)
                        {
                            if (peppeInRange[i])
                            {
                                if (count == randomPick) targetPeppe = pepperonis[i];
                                count++;
                            }
                        }
                 //   Debug.Log(targetPeppe.transform.position);
                        // targetBall = balls[randomPick];
                        chargeDir = targetPeppe.transform.position - transform.position;
                        chargeDir = new Vector3(chargeDir.x, 0, chargeDir.z);
                    transform.LookAt(targetPeppe.transform.position, Vector3.up);
                    switchState("charge");
                    
                }
                else
                {

                    for (int i = 0; i < balls.Length; i++)
                    {
                        Vector3 ballPos = balls[i].transform.position;
                        Vector3 dist = currentPos - ballPos;


                        if (dist.magnitude < 20)
                        {
                            if (i != blindEye || balls[i].GetComponent<Rigidbody>().velocity.magnitude > 1f)
                            {
                                if (
                                    gameObject.GetComponent<MeshRenderer>().material.name 
                                    == balls[i].GetComponent<MeshRenderer>().material.name
                                    )
                                {
                                    ballInRange[i] = true;
                                    inRangeCount++;
                                }
                                
                            }

                        }
                        else ballInRange[i] = false;
                    }

                    if (inRangeCount > 0)
                    {
                        int randomPick = Random.Range(0, inRangeCount);
                        blindEye = randomPick;

                        int count = 0;

                        for (int i = 0; i < balls.Length; i++)
                        {
                            if (ballInRange[i])
                            {
                                if (count == randomPick) targetBall = balls[i];
                                count++;
                            }
                        }
                        // targetBall = balls[randomPick];
                        chargeDir = targetBall.transform.position - transform.position;
                        chargeDir = new Vector3(chargeDir.x, 0, chargeDir.z);
                        switchState("getready");
                    }
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

                transform.position += strayDir.normalized * 0.01f;
                if (timer > 100) switchState("wait");
                break;
        }
        

        timer++;
    }

    void switchState(string newstate)
    {
       // Debug.Log(newstate);
        state = newstate;
        timer = 0;
    }

 

    private void OnCollisionStay(Collision collision)
    {
        if (state == "charge" || state == "stray")
        {
            if (collision.gameObject.tag == "Ball")
            {
                if (
                     gameObject.GetComponent<MeshRenderer>().material.name
                     == collision.gameObject.GetComponent<MeshRenderer>().material.name
                   )
                {
                    switchState("wait");
                }
                   
            }

            if (collision.gameObject.tag == "Peppe")
            {
                Destroy(collision.gameObject);
                switchState("wait");
            }

            if (collision.gameObject.tag == "Wall")
            {
                switchState("stray");
                blindEye = -1;

                strayDir = center - transform.position;
                strayDir = new Vector3(strayDir.x, 0, strayDir.z);
               // strayDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            }
        }

        if (collision.gameObject.tag == "player") blindEye = -1;
        

    }
}
