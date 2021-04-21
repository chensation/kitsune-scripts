using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{

    public float WindPush; //= -.78f;
    public static float m_WindRadius = 1f;

    private GameObject player = null;
    private Rigidbody rb = null;
    void Awake()
    {
        m_WindRadius = GetComponent<SphereCollider>().radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            rb = other.attachedRigidbody;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            rb = null;
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            float WindIntensity = m_WindRadius / Vector3.Distance(transform.position, player.transform.position) / 10;
            rb.AddForce((player.transform.position - transform.position).normalized * (WindIntensity + 1) * WindPush, ForceMode.Acceleration);
           
        }
    }

    /*
    void OnTriggerStay(Collider other)
    {
        if(other.attachedRigidbody)
        {
        float WindIntensity = Vector3.Distance(transform.position, other.transform.position) / m_WindRadius;
        other.attachedRigidbody.AddForce((transform.position - other.transform.position) * WindIntensity * other.attachedRigidbody.mass * WindPush * Time.smoothDeltaTime);
        Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
        }
    }
    */
}
