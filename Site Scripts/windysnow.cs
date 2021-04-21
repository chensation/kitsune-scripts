using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windysnow : MonoBehaviour
{

    public GameObject wind;
    public GameObject regularSnow;
    public GameObject windySnow;
    public GameObject cutscene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (wind.activeSelf)
        {
            windySnow.SetActive(true);
            regularSnow.SetActive(false);

            //check if the player never triggered the first cutscene
            if (cutscene.activeSelf)
            {
                cutscene.SetActive(false);
            }

        }
        
    }
}
