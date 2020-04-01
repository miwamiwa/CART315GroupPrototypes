using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peppescript : MonoBehaviour
{
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > 600) Destroy(gameObject);
    }
}
