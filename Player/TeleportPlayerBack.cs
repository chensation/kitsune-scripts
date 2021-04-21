using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerBack : MonoBehaviour
{
    public Transform destination;
    public Animator foganimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(teleportPlayer(other.transform));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(teleportPlayer(collision.transform));
        }
    }

    private IEnumerator teleportPlayer(Transform player)
    {
        foganimator.Play("fogTransition", -1, 0f);
        yield return new WaitForSeconds(1f);
        player.position = destination.position;
    }
}
