using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmotion : MonoBehaviour
{
    bool triggered = false;
    public int dir = 1;
    int frames = 0;
    GameObject target;
    public bool enabled = false;

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
            target.transform.Rotate(-0.0007f*dir*frames,0,0);
            frames+=1;
            if(frames>400)
            {
                Debug.Log("done " + target.transform.rotation.x);
                triggered = false;
                frames = 0;
                GameObject.Find("Button-emergency").GetComponent<platformmotion>().enabled = false;
                GameObject.Find("Button-emergency (1)").GetComponent<platformmotion>().enabled = false;
                GameObject.Find("camTarget").GetComponent<camerafollow>().unpause();
                target.GetComponent<doggoController>().dir = dir;
                if (dir == 1)
                {
                    GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -65f, -21f);
                    GameObject.Find("Button-emergency (1)").transform.position = new Vector3(0f, -51f, -2f);
                    GameObject.Find("ThirdPersonController_LITE").transform.position = new Vector3(0f, -65f, -21f);
                }
                else
                {
                    GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -40f, -13f);
                    GameObject.Find("Button-emergency (1)").transform.position = new Vector3(0f, -48f, 8f);
                    GameObject.Find("ThirdPersonController_LITE").transform.position = new Vector3(0f, -48f, 8f);
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE"&&!triggered && target.GetComponent<doggoController>().dir != dir)
        {
            Debug.Log("boom "+ target.transform.rotation.x);
            triggered = true;
            GameObject.Find("camTarget").GetComponent<camerafollow>().panOut = true;
        }
    }
}
