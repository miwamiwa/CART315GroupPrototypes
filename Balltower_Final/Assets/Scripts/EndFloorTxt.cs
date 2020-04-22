using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndFloorTxt : MonoBehaviour
{
    Text endText;

    void Start()
    {
        endText = GetComponent<Text>();
    }
    
    void Update()
    {
        endText.text = "Your doggo escaped and you couldn't catch up...\nThe last time you saw him was on floor " + CurrentLvl.currentLvl + ".\nTry looking further.";
    }
}
