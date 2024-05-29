using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{

    private PlayerConroller pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player")) // if the plane hits player, kill
        {
            pc.health = 0;
        }
    }
}
