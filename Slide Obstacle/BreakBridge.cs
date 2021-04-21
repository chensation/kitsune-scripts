using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBridge : MonoBehaviour
{
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bridge.GetComponent<Animator>().enabled = true;
        }
    }
}
