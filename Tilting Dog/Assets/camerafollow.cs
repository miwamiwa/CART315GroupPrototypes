using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    int doggyDir = 1;
    int lastDoggyDir = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doggyDir = -1;
        if(doggyDir != lastDoggyDir)
        {
            transform.eulerAngles = new Vector3(
              transform.eulerAngles.x,
              transform.eulerAngles.y + 180,
              transform.eulerAngles.z
        );
        }

        lastDoggyDir = doggyDir;



        GameObject player = GameObject.Find("ThirdPersonController_LITE");
        Vector3 playerPos = player.GetComponent<Transform>().position ;
        Vector3 playerVel = player.GetComponent<Rigidbody>().velocity;
        if (playerVel.z > 0 && doggyDir == 1) playerVel.z = 0;
        if (playerVel.z < 0 && doggyDir == -1) playerVel.z = 0;

        transform.position = playerPos - new Vector3(0, -2f, doggyDir* (2f )- playerVel.z );
        
    }
}
