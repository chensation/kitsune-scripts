using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SlideController>().EnableSliding();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SlideController>().DisableSliding();
        }
    }

    private void OnTriggerEnter(Collider Trigger)
    {
        if (Trigger.gameObject.CompareTag("Player"))
        {
            Trigger.gameObject.GetComponent<SlideController>().EnableSliding();
        }
    }

    private void OnTriggerExit(Collider Trigger)
    {
        if (Trigger.gameObject.CompareTag("Player"))
        {
            Trigger.gameObject.GetComponent<SlideController>().DisableSliding();
        }
    }

    
}
