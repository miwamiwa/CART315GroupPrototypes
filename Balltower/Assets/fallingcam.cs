using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingcam : MonoBehaviour
{
    public bool falling = false;
    public GameObject arrow;
    public GameObject trigger;

    void Update()
    {
        if(falling)
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.001f;

        arrow.transform.LookAt(trigger.transform, -arrow.transform.up);
        arrow.transform.Rotate(new Vector3(-90, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            GameObject.Find("Main Camera").GetComponent<smoothefollow>().movementTime = 0.24f;
            falling = false;
        }
    }
}
