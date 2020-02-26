using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreballs : MonoBehaviour
{
    public GameObject newball;
    // Start is called before the first frame update
    public bool canSpawn = false;
    public Material mat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE" && canSpawn)
        {
            GameObject theball = GameObject.Instantiate(newball, gameObject.transform.position, Quaternion.identity);
            Vector2 randpos = Random.insideUnitCircle * 1f;
            theball.transform.position = GameObject.Find("spawnpoint").transform.position;
            theball.GetComponent<moreballs>().canSpawn = false;
            theball.GetComponent<Renderer>().material = mat;
        }
    }
}
