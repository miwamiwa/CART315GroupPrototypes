using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoniShooter : MonoBehaviour
{
    public GameObject pepperonis;
    public GameObject spawn;
    public Vector3 directionVector;
    public float spawnRate;
    public float minVelocity;
    public float maxVelocity;

    private void Start()
    {
        StartCoroutine(SpawnPeperonis());
    }

    private IEnumerator SpawnPeperonis()
    {
        while (true)
        {
            GameObject instance = Instantiate(pepperonis, spawn.transform);
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            float randomVelocity = Random.Range(minVelocity, maxVelocity);
            rb.velocity = directionVector * randomVelocity;

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
