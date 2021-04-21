using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Tail")
        {
            collision.gameObject.GetComponent<TailFire>().douse();
        }
    }
}
