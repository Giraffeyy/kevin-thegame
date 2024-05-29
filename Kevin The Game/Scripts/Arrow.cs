using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Gunman gunmanScript;
    Enemy enemyScript;
    Boss bossScript;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) // when colliding
    {
        if (other.gameObject.name == "Enemy(Clone)" || other.gameObject.name == "TutEnemy" || other.gameObject.name == "Gunman(Clone)" || other.gameObject.name == "Boss(Clone)")
        { // if we hit an enemy
            if(other.gameObject.name == "Gunman(Clone)") // if we hit a gunman
            {
                gunmanScript = other.gameObject.GetComponent<Gunman>();//get the script
                gunmanScript.health = gunmanScript.health - damage;// do damage
                gunmanScript.UpdateHealthBar();// update the gunman health bar
            } 
            else if (other.gameObject.name == "Boss(Clone)")//if we hit boss
            {
                bossScript = other.gameObject.GetComponent<Boss>();
                bossScript.TakeDamage(damage);// make boss take damage
            }
            else { // otherwise
                enemyScript = other.gameObject.GetComponent<Enemy>();
                enemyScript.health = enemyScript.health - damage;//make normal enemy take damage
                enemyScript.UpdateHealthBar();
            }  
        }
    }
}
