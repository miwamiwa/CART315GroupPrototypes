using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonPress : MonoBehaviour
{
    [SerializeField] private Animator animationController;
    public GameObject dogs;
    public GameObject spawnDog1;
    public GameObject spawnDog2;
    public GameObject spawnDog3;
    public GameObject spawnDog4;
    public GameObject spawnDog5;
    public float dogSpeed;
    public Material dogColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("PlayPress", true);
            dogs.GetComponent<Renderer>().material = dogColor;
            GameObject instance1 = Instantiate(dogs, spawnDog1.transform);
            GameObject instance2 = Instantiate(dogs, spawnDog2.transform);
            GameObject instance3 = Instantiate(dogs, spawnDog3.transform);
            GameObject instance4 = Instantiate(dogs, spawnDog4.transform);
            GameObject instance5 = Instantiate(dogs, spawnDog5.transform);
            Rigidbody rb1 = instance1.GetComponent<Rigidbody>();
            Rigidbody rb2 = instance2.GetComponent<Rigidbody>();
            Rigidbody rb3 = instance3.GetComponent<Rigidbody>();
            Rigidbody rb4 = instance4.GetComponent<Rigidbody>();
            Rigidbody rb5 = instance5.GetComponent<Rigidbody>();
            rb1.velocity = new Vector3(0, -dogSpeed, 0);
            rb2.velocity = new Vector3(0, -dogSpeed, 0);
            rb3.velocity = new Vector3(0, -dogSpeed, 0);
            rb4.velocity = new Vector3(0, -dogSpeed, 0);
            rb5.velocity = new Vector3(0, -dogSpeed, 0);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("PlayPress", false);
        }
    }
}
