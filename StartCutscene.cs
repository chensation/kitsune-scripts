using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{

    public GameObject playerCharacter;
    public GameObject cutsceneCamera;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCamera.SetActive(true);
        StartCoroutine(FinishCutscene());
       
    }

    IEnumerator FinishCutscene()
    {
        yield return new WaitForSeconds(36);
        cutsceneCamera.SetActive(false);
    }
}
