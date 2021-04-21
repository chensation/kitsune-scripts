using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private float speed;
    public float speedLowBound = 2.0f;
    public float speedHighBound = 7.0f;

    public bool backwards = false;
    private float inverse = 1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedLowBound, speedHighBound);
        rb = GetComponent<Rigidbody>();

        if (backwards)
        {
            inverse = -1f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tempVect = transform.TransformDirection(transform.right * inverse);
        tempVect = tempVect * speed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + tempVect);
    }
    
    public void Reset()
    {
        speed = Random.Range(speedLowBound, speedHighBound);
    }

    
}
