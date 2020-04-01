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

        string matName1 = (mat1.name + " (Instance)");
        string matName2 = (mat2.name + " (Instance)");
        string matName3 = (mat3.name + " (Instance)");
        string matName4 = (mat4.name + " (Instance)");
        string matName5 = (mat5.name + " (Instance)");

        if (collision.gameObject.tag == "Dog")
        {
            Debug.Log("dog");
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name == matName1)
            {
                Debug.Log("yo");
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name == matName2)
            {
                Debug.Log("yo");
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name == matName3)
            {
                Debug.Log("yo");
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name == matName4)
            {
                Debug.Log("yo");
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name == matName5)
            {
                Debug.Log("yo");
                Destroy(collision.gameObject);
            }
        }
    }
}
