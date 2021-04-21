using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTeleporter : MonoBehaviour
{
    GameController gameController;
    public Animator fireanimator;
    
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (gameController.currentTeleport < gameController.temples.Count - 1)
        {
            gameController.currentTeleport++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Wait());
        
        }
    }

    IEnumerator Wait()
    {
        fireanimator.Play("firetransitionimage", -1, 0f);
        yield return new WaitForSeconds(1f);
        gameController.TeleportToTemple();

    }
}
