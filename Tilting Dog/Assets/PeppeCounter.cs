using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeppeCounter : MonoBehaviour
{
    
    Text pepeCount; 

    // Start is called before the first frame update
    void Start()
    {
        pepeCount = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        pepeCount.text = "Pepperoni Counter: " + pepebutton.peppeNum;
    }
}
