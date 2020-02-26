using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformtrigger : MonoBehaviour
{
    public GameObject targetplatform;
    public BallSpawner spawner = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
