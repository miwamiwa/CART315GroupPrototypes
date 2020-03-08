using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public float forceMult = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -70f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "ThirdPersonController_LITE")
        {
            float f = transform.position.z - collision.gameObject.transform.position.z;
            Debug.Log(f*forceMult);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0,0,-f*forceMult, ForceMode.Acceleration);
        }
    }
}
