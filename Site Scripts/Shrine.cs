using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    [Tooltip("Place the fire object that'll be enable in here")]
    [SerializeField]
    GameObject bonefire;

    [Tooltip("Place the index that corresponds to the one on the map")]
    [SerializeField]
    int index;

    [SerializeField]
    GameObject map;

    bool called = false;

    private void Update()
    {
        if (!called && bonefire.activeSelf)
        {
            map.GetComponent<Map>().LightShrineOnMap(index);
            called = true;
        }

    }

}
