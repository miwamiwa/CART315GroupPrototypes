using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    bool pushed = false;
    bool lastState = false;
    float resetTime = 0f;
    float resetTime2 = 0f;
    int counter = 0;
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pushed && !lastState) counter = 0;
        

        if (pushed && lastState)
        {
            Vector3 t = transform.Find("Circle").transform.position;
            
            if (counter>35)
            {

                if (counter > 200)
                {
                    transform.Find("Circle").transform.position = new Vector3(t.x + 0.009f, t.y, t.z);
                    if (counter > 235) pushed = false;
                    
                   
                }
                
            }
            else transform.Find("Circle").transform.position = new Vector3(t.x - 0.009f, t.y, t.z);

            counter++;
        }

        lastState = pushed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pushed = true;
            Debug.Log("pushin");
        }
    }
}
