using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepebutton : MonoBehaviour
{
    public static int peppeNum;
    
    // Start is called before the first frame update
    void Start()
    {
        peppeNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE")
        {
            Destroy(gameObject);
            peppeNum++;
        }
    }
}
