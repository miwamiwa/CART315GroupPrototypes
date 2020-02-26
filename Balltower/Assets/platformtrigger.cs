using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformtrigger : MonoBehaviour
{
    public GameObject targetplatform;
    public BallSpawner spawner = null;
    public GameObject beam;

    float nextTime = 0f;
    public float interval = 8f;
    public float displayTime = 3f;
    bool displayed = false;
    Quaternion beamrot;

    // Start is called before the first frame update
    void Start()
    {
        beam = GameObject.Find("arrow");
        beam.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        beam.transform.rotation = beamrot;

        if (Time.time > nextTime)
        {
            displayed = !displayed;

            if (displayed)
            {
                beam.SetActive(true);
                nextTime = Time.time + displayTime;
            }
            else
            {
                nextTime = Time.time + interval;
                beam.SetActive(false);
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE")
        {
            // platform fall.
            targetplatform
                .GetComponent<fallingscript>()
                .falling = true;
                Renderer renderer = GetComponent<Renderer>();
                spawner.SpawnBalls(renderer.material.color);
        }
    }
}
