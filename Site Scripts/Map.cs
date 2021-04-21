using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [Tooltip("Make sure the count and index match with shrines")]
    public List<GameObject> shrinesOnMap;

    public GameObject templeOnMap;

    int numLitShrine = 0;

    private void Update()
    {
        if(numLitShrine == shrinesOnMap.Count && !templeOnMap.activeSelf)
        {
            templeOnMap.SetActive(true);
        }
    }

    public void LightShrineOnMap(int index)
    {
        shrinesOnMap[index].SetActive(true);
        numLitShrine++;
    }
}
