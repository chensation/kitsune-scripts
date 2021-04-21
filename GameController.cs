using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public bool hideCursor = false;

	public List<GameObject> temples;

	public int currentTeleport = -1;

    private void Start()
    {
        Cursor.visible = !hideCursor;
    }

    public void TeleportToTemple()
    {
        Transform player = GameObject.FindWithTag("Player").transform;

        foreach (Transform child in temples[currentTeleport].transform)
        {
            if (child.CompareTag("Teleport"))
            {
                player.position = child.position;
                break;
            }
        }
        temples[currentTeleport].GetComponent<Temple>().OpenDoor();

    }
}
