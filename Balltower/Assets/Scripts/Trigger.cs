using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public BallSpawner spawner = null;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //spawn balls
            Renderer renderer = GetComponent<Renderer>();
            spawner.SpawnBalls(renderer.material.color);
        }
    }
}
