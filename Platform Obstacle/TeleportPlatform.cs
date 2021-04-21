using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlatform : MonoBehaviour
{
    public Transform toPos;
    GameObject platform;
    Rigidbody rb;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            if (collision.GetComponent<Rigidbody>())
            {
                platform = collision.gameObject;
            }
            else
            {
                platform = collision.transform.parent.gameObject;
            }

            rb = platform.GetComponent<Rigidbody>();
            platform.transform.position = new Vector3(toPos.position.x, rb.position.y, rb.position.z);
            platform.GetComponent<Platform>().Reset();

        }
    }
}
