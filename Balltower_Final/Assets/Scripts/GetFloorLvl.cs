using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFloorLvl : MonoBehaviour
{
    Text floor;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        floor = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        level = GameObject.Find("Trigger").GetComponent<platformtrigger>().levelCount;
        floor.text = "Level " + (level + 1);
    }
}
