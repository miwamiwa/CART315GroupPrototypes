using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform spawnPoint;//Add empty gameobject as spawnPoint
    public float deathHeight = -80.0f;

    void FixedUpdate()
    {
        if (transform.position.y < deathHeight)
        {
            transform.position = spawnPoint.position;
        }

    }
}
