﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball = null;
    public List<Transform> ballTransform = null;
    public float maxVelocity = 3f;
    public Material mat = null;
    float level = 1;

    public void SpawnBalls(Color color)
    {
        level+=0.5f;
        //level++;
         float levelInt = Mathf.Round(level);
       // float levelInt = level;
        for(int i=0; i<levelInt; i++)
        {
            foreach (Transform transform in ballTransform)
            {

                GameObject newBall = Instantiate(ball, transform.position + new Vector3(0,i*2,0), Quaternion.identity);
                newBall.GetComponent<moreballs>().canSpawn = false;
                Renderer renderer = newBall.GetComponent<Renderer>();
                Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
                rigidbody.velocity = new Vector3(Random.Range(0f, maxVelocity), Random.Range(0f, maxVelocity), Random.Range(0f, maxVelocity));
                renderer.material = mat;
            }
        }
        
    }
}