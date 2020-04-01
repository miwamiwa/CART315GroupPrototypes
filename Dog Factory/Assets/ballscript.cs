using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float speed = 10;
        Vector3 force =  Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody>().AddForce(force * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
