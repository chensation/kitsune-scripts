using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("GameManager").TryGetComponent(out GameManager manager))
            {
                manager.Respawn(collision.gameObject);
            }
        }
    }
}
