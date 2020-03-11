using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbutton : MonoBehaviour
{

    private float lastSpawn = 0;
    float spawnInterval = 4f;
    public GameObject ball;
    float offset = 0;
    // Start is called before the first frame update
   private void Start()
    {
       
        lastSpawn = Random.Range(0, spawnInterval);
        //Debug.Log(lastSpawn);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > lastSpawn)
        {
            GameObject newBall = Instantiate(ball, transform.position + new Vector3(0, 3f, 0), transform.rotation) ;
            lastSpawn = Time.time + Random.Range(0, 6f);
        }
    }


}
