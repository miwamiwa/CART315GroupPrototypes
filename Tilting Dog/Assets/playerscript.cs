using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -75f)
        {
            int dir = GameObject.Find("camTarget").GetComponent<camerafollow>().doggyDir;
            if (dir == 1)
            {
                //  GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -65f, -21f);

                GameObject.Find("ThirdPersonController_LITE").transform.position = new Vector3(0f, -60f, -21f);

            }
            else
            {
                //  GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -40f, -13f);
                GameObject.Find("ThirdPersonController_LITE").transform.position = new Vector3(0f, -45f, 8f);
            }
        }
    }
}
