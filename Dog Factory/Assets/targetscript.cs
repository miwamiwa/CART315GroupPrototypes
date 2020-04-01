using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetscript : MonoBehaviour
{
    public Material DogMaterial;
    
    private void OnCollisionStay(Collision collision)
    {

        string matName = (DogMaterial.name + " (Instance)");

        if (collision.gameObject.tag == "Dog")
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.name == matName)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
