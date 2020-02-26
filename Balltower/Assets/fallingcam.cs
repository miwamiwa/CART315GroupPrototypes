using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingcam : MonoBehaviour
{
    public bool falling = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.001f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name== "Floor")
        {
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.24f;
            falling = false;
        }
    }
}
