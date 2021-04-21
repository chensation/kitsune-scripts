using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailFire : MonoBehaviour
{
    public bool lit = false;

    private void Start()
    {
        if (lit)
        {
            this.light();
        }
        else
        {
            this.douse();
        }
    }
    public void light() //light the fire
    {
        transform.GetChild(0).gameObject.SetActive(true);
        lit = true;
    }

    public void douse() //douse the fire
    {
        transform.GetChild(0).gameObject.SetActive(false);
        lit = false;
    }
}
