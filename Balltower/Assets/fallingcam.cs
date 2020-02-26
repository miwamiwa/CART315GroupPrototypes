using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingcam : MonoBehaviour
{
    public bool falling = false;
    public GameObject arrow;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
      //  arrow = GameObject.Find("arrow");
      //  trigger = GameObject.Find("Trigger");
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.001f;


        arrow.transform.LookAt(
           trigger.transform, arrow.transform.up);
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
