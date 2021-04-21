using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnceLit : MonoBehaviour
{
    [Tooltip("Place the fire object to enables here")]
    [SerializeField]
    GameObject bonefire;

    bool called = false;

    // Update is called once per frame
    void Update()
    {
        if (!called && bonefire.activeSelf)
        {
            gameObject.GetComponent<MeshCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            called = true;
        }

    }
}
