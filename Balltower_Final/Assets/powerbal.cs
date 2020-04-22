using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerbal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int level = GameObject.Find("Trigger").GetComponent<platformtrigger>().levelCount;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.mass += level * 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Trigger" )
        {
            GameObject dog = GameObject.Find("Trigger");

            AudioSource dogAudio = dog.GetComponent<AudioSource>();
            dogAudio.clip = dog.GetComponent<platformtrigger>().yip;
            dogAudio.volume = 0.2f;
            dogAudio.pitch = 1f;
            dogAudio.Play();


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }
}
