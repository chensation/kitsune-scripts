using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : MonoBehaviour
{
    public GameObject fire;
    public bool lit = false;
    private void Start()
    {
        if (lit)
        {
            fire.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tail")
        {

            TailFire tail = other.GetComponent<TailFire>();

            if (tail.lit) //if tail is lit, set latern on fire
            {
                fire.SetActive(true);
                lit = true;
            }
            else if(lit) // if latern is lit, set tail on fire
            {
                tail.light();
            }

        }
        
    }
}
