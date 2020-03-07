using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("ThirdPersonController_LITE");
        Vector3 playerPos = player.GetComponent<Transform>().position ;
        Vector3 playerVel = player.GetComponent<Rigidbody>().velocity;
        if (playerVel.z > 0) playerVel.z = 0;
        transform.position = playerPos - new Vector3(0, -2f, 2f - playerVel.z) ;
    }
}
