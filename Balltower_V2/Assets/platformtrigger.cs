using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformtrigger : MonoBehaviour
{
    public GameObject targetplatform;
    public BallSpawner spawner = null;
    public GameObject arrow;
    public GameObject ArrowTrigger;

    public int numberOfArrowTriggers = 10;

    float nextTime = 0f;
    public float interval = 8f;
    public float displayTime = 3f;
    bool displayed = false;
    Quaternion beamrot;
    int levelCount = 0;

    bool resetCollision = false;
    float resetTime = 0f;

    float barkTime = 0.8f;
    public float minBarkInterval = 1f;
    public float barkIntervalRange = 3f;
    AudioSource audio;


    float nextMove = 1f;
    float stopTime = 1.5f;
    float timeBetweenMoves = 1f;
    float maxMove = 1f;
    Vector3 moveBearing;

    bool callTriggered = false;
    float barkResetTime = 0f;
    bool barked = false;

    public int roundsUntilBallReset = 5;

    AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject[] triggers = GameObject.FindGameObjectsWithTag("arrowtrigger");
        audio = GetComponent<AudioSource>();
        playerAudio = GameObject.Find("ThirdPersonController_LITE").GetComponent<AudioSource>();
        playerAudio.volume = 0.7f;
        triggerMoreArrows();

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;

        if(time > nextMove)
        {
            moveBearing = new Vector3(Random.Range(-maxMove, maxMove), 0f, Random.Range(-maxMove, maxMove)).normalized;
            nextMove = time + timeBetweenMoves;
            stopTime = time + timeBetweenMoves / 2;
            transform.rotation = Quaternion.LookRotation(moveBearing);
        }
        else if(time < stopTime)
        {
            Vector3 pos = gameObject.transform.position;
            gameObject.transform.position = pos + moveBearing / 10f;
        }

        if ( Input.GetKeyDown("q") && !callTriggered )
        {
            // trigger whistle here
            playerAudio.pitch = Random.Range(0.8f, 1.2f);
            playerAudio.Play();
            callTriggered = true;
            barkTime = time + Random.Range(minBarkInterval, minBarkInterval + barkIntervalRange);
            barkResetTime = barkTime + 0.5f;
        }

        if (time > barkTime &&callTriggered )
        {
            if (!barked)
            {
                // trigger bark 
                audio.pitch = 1f;
                audio.Play();
                barked = true;
            }

            if (time > barkResetTime)
            {
                callTriggered = false;
                barked = false;
            }
        }


        if (resetCollision)
        {
            if (time > resetTime)
            {
                resetCollision = false;
            }
        }
     //   arrow.transform.rotation = beamrot;

    }

    void triggerMoreArrows()
    {
        for (int i = 0; i < numberOfArrowTriggers; i++)
        {
            GameObject newArrowTrigger = Instantiate(ArrowTrigger, transform.position, Quaternion.identity);
            Vector3 bounds = gameObject.GetComponent<Collider>().bounds.size;
            Vector3 pos = GameObject.Find("middlepoint").transform.position;
            Vector2 randpos = Random.insideUnitCircle * bounds.z * .3f;

            newArrowTrigger.transform.position = new Vector3(
                pos.x + randpos.x,
                pos.y + bounds.y + 2f,
                pos.z + randpos.y
                );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE"&&!resetCollision)
        {
            // trigger audio 
            audio.pitch = 0.5f;
            audio.Stop();
            audio.Play();
            barkTime = Time.time + Random.Range(minBarkInterval/2, minBarkInterval/2 + barkIntervalRange/2);

            // disable collision for a second
            resetCollision = true;
            resetTime = Time.time + 3f;

            // reset arrow triggers
            GameObject[] triggers = GameObject.FindGameObjectsWithTag("arrowtrigger");
            for(int i=0; i<triggers.Length; i++)
            {
                Destroy(triggers[i]);
            }
            triggerMoreArrows();

            // update level count 
            levelCount++;


            if (levelCount % roundsUntilBallReset == 0)
            {
                // destroy balls
                GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");

                for (int i = 0; i < balls.Length; i++)
                {
                    Destroy(balls[i]);
                }
            }


            // platform fall.
            targetplatform
                .GetComponent<fallingscript>()
                .falling = true;
                Renderer renderer = GetComponent<Renderer>();

            spawner.SpawnBalls(renderer.material.color);
        }
    }
}
