using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Attack : MonoBehaviour
{

    public TextMeshProUGUI health;
    public bool attackCooldown;
    private float attackTime;
    private GameObject player;
    PlayerConroller pController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        pController = player.GetComponent<PlayerConroller>(); // get player controller
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) // when the enemy attacks and hits something
    {
        if (Time.time > (attackTime + 2)) {//set up attack cooldown
            attackCooldown = false;
        }
        if(collision.gameObject.CompareTag("player") && attackCooldown == false)//if the enemy hits player and is also not on cooldown
        {
            attackCooldown = true;
            attackTime = Time.time;
            pController.health -= 5;// do damage
        }
    }

}
