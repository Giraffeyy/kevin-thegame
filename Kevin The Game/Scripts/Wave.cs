using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // when we collide with the player
    {
        if (other.gameObject.CompareTag("player"))
        {
            spawnManager.wavingOne = true;
            spawnManager.SpawnEnemyWave(5);// spawn in the first enemy wave using spawnmanager
            Destroy(gameObject); // estroy the wave spawner
        }
        
    }
}
