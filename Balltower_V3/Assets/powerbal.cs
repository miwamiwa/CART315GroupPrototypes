using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerbal : MonoBehaviour
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
        if (collision.gameObject.name == "Trigger" )
        {
            GameObject dog = GameObject.Find("Trigger");

            AudioSource dogAudio = dog.GetComponent<AudioSource>();
            dogAudio.clip = dog.GetComponent<platformtrigger>().yip;
            dogAudio.volume = 0.5f;
            dogAudio.pitch = 1f;
            dogAudio.Play();


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }
}
