using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private bool canTakeDamage = true;
    public float enemyDamage;
    PlayerConroller pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>(); // get playercontroller
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // if the bullet hits soemthing
    {
        if(other.gameObject.name == "Player") // if it hits the player
        {
            if(canTakeDamage == true) // the bullet hasnt already hit the player
            {
                canTakeDamage = false;
                pc.TakeDamage(enemyDamage); // get hte player to take damage
            }
            
        }
    }
}
