using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to play the fire transition exit half when you load this scene from the start menu.



public class FireTrans : MonoBehaviour
{

    public GameObject StartTransition;
    public Animator fireanimator;

    // Start is called before the first frame update
    void Start()
    {
        StartTransition.SetActive(true);
        fireanimator = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
