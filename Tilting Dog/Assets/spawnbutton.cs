using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbutton : MonoBehaviour
{

    float lastSpawn = 0;
    public float spawnInterval = 4f;
    public GameObject ball;
    float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        float offset = Random.Range(0, spawnInterval);
        lastSpawn = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawn)
        {
            GameObject newBall = Instantiate(ball, transform.position + new Vector3(0, 2f, 0), transform.rotation) ;
            lastSpawn = Time.time + spawnInterval;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE")
        {
            Destroy(gameObject);
        }
    }
}
