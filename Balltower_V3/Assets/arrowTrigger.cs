﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTrigger : MonoBehaviour
{
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
        if(collision.gameObject.name== "ThirdPersonController_LITE")
        {
            collision.gameObject.GetComponent<fallingcam>().triggerArrow();
            Destroy(gameObject);
        }
    }
}
