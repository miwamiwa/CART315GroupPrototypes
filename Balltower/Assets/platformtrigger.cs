using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformtrigger : MonoBehaviour
{
    public GameObject targetplatform;
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

        }
    }
}
