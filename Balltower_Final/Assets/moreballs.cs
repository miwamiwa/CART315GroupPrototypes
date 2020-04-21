using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreballs : MonoBehaviour
{
    public GameObject newball;
    // Start is called before the first frame update
    public bool canSpawn = false;
    public Material mat;
    bool hasSpawned = false;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (
            !audio.isPlaying
            //&&collision.gameObject.name!="Floor"
            )
        {
            Vector3 distToPlayer = gameObject.transform.position - GameObject.Find("ThirdPersonController_LITE").transform.position;
            int level = GameObject.Find("Trigger").GetComponent<platformtrigger>().levelCount;

            int treshold = 20 - level;
            if (treshold < 1) treshold = 1;

            if ( distToPlayer.magnitude < treshold )
            //  Debug.Log(collision.impactForceSum.magnitude);
            audio.volume = collision.impactForceSum.magnitude / 30f;
            audio.Play();
        }
        if (collision.gameObject.name=="Trigger"&&gameObject.GetComponent<Rigidbody>().velocity.magnitude > 40f)
        {
            GameObject dog = GameObject.Find("Trigger");

            AudioSource dogAudio = dog.GetComponent<AudioSource>();
            dogAudio.clip = dog.GetComponent<platformtrigger>().yip;
            dogAudio.pitch = 1f;
            dogAudio.volume = 0.5f;
            dogAudio.Play();


        }
        if (collision.gameObject.name == "ThirdPersonController_LITE"  )
        {
            if (!hasSpawned)
            {
                GameObject theball = GameObject.Instantiate(newball, gameObject.transform.position, Quaternion.identity);
                Vector2 randpos = Random.insideUnitCircle * 1f;
                theball.transform.position = GameObject.Find("spawnpoint").transform.position;
                theball.GetComponent<moreballs>().canSpawn = false;
                hasSpawned = true;
                theball.GetComponent<Renderer>().material = mat;
            }
        

            if (collision.gameObject.transform.position.y > gameObject.transform.position.y)
            {
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<fallingcam>().isOnBall = true;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        

        if (collision.gameObject.name == "ThirdPersonController_LITE")
        {
           
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<fallingcam>().isOnBall = false;
            }
        
    }
}
