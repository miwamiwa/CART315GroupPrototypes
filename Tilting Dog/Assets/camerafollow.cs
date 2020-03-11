using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    int doggyDir = -1;
    int lastDoggyDir = 1;
    int tick = 0;
    GameObject dog;
    public bool panOut = false;
    bool prevPanOut = false;
    float displacement = 0f;
    Vector3 initialPosition;
    public bool pause = true;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("DOGGOANIM");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (doggyDir != lastDoggyDir)
        {
            GameObject.Find("spawner").GetComponent<buttonspawner>().DestroyButtons();
            GameObject.Find("spawner").GetComponent<buttonspawner>().SpawnButtons(doggyDir);
            transform.eulerAngles = new Vector3(
              transform.eulerAngles.x,
              transform.eulerAngles.y + 180,
              transform.eulerAngles.z
        );

            if (doggyDir == 1)
            {
                //  GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -65f, -21f);
                
                GameObject.Find("ThirdPersonController_LITE").transform.position = new Vector3(0f, -60f, -21f);

            }
            else
            {
                //  GameObject.Find("Button-emergency").transform.position = new Vector3(0f, -40f, -13f);
                GameObject.Find("ThirdPersonController_LITE").transform.position = new Vector3(0f, -45f, 8f);
            }
            Rigidbody rb = GameObject.Find("ThirdPersonController_LITE").GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        lastDoggyDir = doggyDir;

        
        if (panOut && !prevPanOut)
        {
            displacement = 0f;
            tick = 0;
            pause = true;
            transform.eulerAngles = new Vector3(
              transform.eulerAngles.x,
              transform.eulerAngles.y - 90,
              transform.eulerAngles.z
              );

            initialPosition = transform.position;
        }

        prevPanOut = panOut;

        if (panOut)
        {
            
            displacement += doggyDir*0.12f;
            tick++;
            if(tick >= 380)
            {
                if (!pause)
                {
                   
                }
                else
                {
                   // GameObject.Find("Button-emergency").GetComponent<platformmotion>().enabled = true;
                    GameObject.Find("Button-emergency (1)").GetComponent<platformmotion>().enabled = true;
                }
                

                
            }
            else transform.position = initialPosition + new Vector3(displacement, 0, 0);
        }
        else
        {
            GameObject player = GameObject.Find("ThirdPersonController_LITE");
            Vector3 playerPos = player.GetComponent<Transform>().position;
            Vector3 playerVel = player.GetComponent<Rigidbody>().velocity;
            if (playerVel.z > 0 && doggyDir == 1) playerVel.z = 0;
            if (playerVel.z < 0 && doggyDir == -1) playerVel.z = 0;

            transform.position = playerPos - new Vector3(0, -2f, doggyDir * (2f) - playerVel.z);
        }        
    }

    public void unpause()
    {
        doggyDir *= -1;
        panOut = false;
        transform.eulerAngles = new Vector3(
      transform.eulerAngles.x,
      transform.eulerAngles.y + 90,
      transform.eulerAngles.z
      );
    }
}
