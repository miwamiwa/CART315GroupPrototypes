using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingscript : MonoBehaviour
{
    public bool falling = false;
    int fallcount = 0;
    
    GameObject trig;
    // Start is called before the first frame update
    void Start()
    {
        trig = GameObject.Find("Trigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            if (fallcount == 0)
            {
                
                


                GameObject.Find("ThirdPersonController_LITE").GetComponent<fallingcam>().falling = true; ;
                trig.transform.rotation = Random.rotation;
                Rigidbody rigidbody = trig.GetComponent<Rigidbody>();
                rigidbody.AddForce(trig.transform.forward * 1000);
            }

            Vector3 currentpos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(currentpos.x, currentpos.y - fallcount / 100f, currentpos.z);
            fallcount++;

            

            if (fallcount > 50)
            {
                Vector3 bounds = gameObject.GetComponent<Collider>().bounds.size;
                Vector3 pos = GameObject.Find("middlepoint").transform.position;
                Vector2 randpos = Random.insideUnitCircle * bounds.z*.3f;
                //Debug.Log("floor level " + gameObject.transform.position.y);
                trig.transform.position = new Vector3(
                    pos.x + randpos.x,
                    pos.y + bounds.y+2f,
                    pos.z +  randpos.y
                    ) ;
                falling = false;
                GameObject.Find("Trigger").GetComponent<platformtrigger>().flying = true;
                fallcount = 0;
            }
        }
    }
}
