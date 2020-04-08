using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    public float time = 10f; 

    void Start()
    {
        Destroy(gameObject, time);
    }
}
