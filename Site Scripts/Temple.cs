using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple : MonoBehaviour
{
    [SerializeField]
    private GameObject door1;
    [SerializeField]
    private GameObject door2;
    [SerializeField]
    private GameObject lightBeam;

    public void OpenDoor()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        lightBeam.SetActive(true);
    } 
}
