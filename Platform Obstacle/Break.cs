using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(breakIce(GetComponent<Animator>()));
        }
    }

    IEnumerator breakIce(Animator anim)
    {
        yield return new WaitForSeconds(0.75f);
        anim.enabled = true;
    }
}
