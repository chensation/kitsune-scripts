using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [Tooltip("Place the fire object disable the fog here")]
    [SerializeField]
    GameObject bonefire;

    bool called = false;

    // Update is called once per frame
    void Update()
    {
        if (!called && bonefire.activeSelf)
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
            called = true;
        }

    }
}
