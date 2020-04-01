using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonPress : MonoBehaviour
{
    [SerializeField] private Animator animationController;
    public GameObject dogs;
    public GameObject balls;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
    public float dogSpeed;
    public Material objMat;
    private GameObject randomObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("PlayPress", true);


            dogs.GetComponent<Renderer>().material = objMat;
            balls.GetComponent<Renderer>().material = objMat;
            choseObject();
            GameObject instance1 = Instantiate(randomObject, spawner1.transform);
            choseObject();
            GameObject instance2 = Instantiate(randomObject, spawner2.transform);
            choseObject();
            GameObject instance3 = Instantiate(randomObject, spawner3.transform);
            choseObject();
            GameObject instance4 = Instantiate(randomObject, spawner4.transform);
            choseObject();
            GameObject instance5 = Instantiate(randomObject, spawner5.transform);

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

    private void choseObject()
    {
        if (Random.Range(1,3) == 2)
        {
            randomObject = dogs;
        } else
        {
            randomObject = balls;
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
