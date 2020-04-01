using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetscript : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Dog")
        {
            Debug.Log("dog");
            if (collision.gameObject.GetComponent<Renderer>().material==mat1)
            {
                Debug.Log("yo");
                Destroy(collision.gameObject);
            }
        }
    }
}
