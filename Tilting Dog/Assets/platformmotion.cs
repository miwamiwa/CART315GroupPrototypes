using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmotion : MonoBehaviour
{
    bool triggered = false;
    int dir = -1;
    int frames = 0;
    GameObject target;
    public bool enabled = false;
    float nextTrigger = 5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("DOGGOANIM");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (triggered&&enabled)
        {

            Debug.Log("triggered");
            target.transform.Rotate(0.0007f*dir*frames,0,0);
            frames+=1;
            if(frames>400)
            {
                Debug.Log("done " + target.transform.rotation.x);
                triggered = false;
                frames = 0;
               // GameObject.Find("Button-emergency").GetComponent<platformmotion>().enabled = false;
                GameObject.Find("Button-emergency (1)").GetComponent<platformmotion>().enabled = false;
                GameObject.Find("camTarget").GetComponent<camerafollow>().unpause();
                
                target.GetComponent<doggoController>().dir = dir;
                
                dir *= -1;
            }
        }

        if (Time.time > nextTrigger)
        {
            triggered = true;
            GameObject.Find("camTarget").GetComponent<camerafollow>().panOut = true;
            nextTrigger = Time.time + 20f;
        }
    }

}
