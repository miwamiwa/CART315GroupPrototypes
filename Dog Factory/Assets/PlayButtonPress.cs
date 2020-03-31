using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonPress : MonoBehaviour
{
    [SerializeField] private Animator animationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("PlayPress", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("PlayPress", false);
        }
    }
}
