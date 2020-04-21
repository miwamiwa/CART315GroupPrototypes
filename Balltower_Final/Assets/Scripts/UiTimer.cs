using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    public float time = 60f; 

    void Start()
    {
        Destroy(gameObject, time);
    }
}
