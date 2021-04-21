using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditController : MonoBehaviour
{
    public string startScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            returnToStart();
        }

        
    }

    public void returnToStart()
    {
        GetComponent<SceneTransition>().ChangeScene(startScene);
    }
}
