using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
    PlayerConroller pc;
    public iTween.EaseType easetype;
    public iTween.LoopType looptype;
    public bool rotating = false;
    Sword sword;
    GameObject player;
    GameObject sa;
    Animator swordAnim;
    Enemy enemyScript;
    Gunman gunmanScript;
    Boss bossScript;
    private bool ouching;
    public GameObject ouch;
    Owching owching;

    // Start is called before the first frame update
    void Start()
    {

        // initialize variables

        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        player = GameObject.Find("Player");
        sword = player.GetComponent<Sword>();
        sa = GameObject.Find("Armsword");
        swordAnim = sa.GetComponent<Animator>();
        owching = ouch.GetComponent<Owching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) // when we attack
        {
            if(pc.swordTrue == true) // if we hae the sword out
            {
                if (rotating == false) // if we arent already hitting
                {
                    rotating = true;

                    StartCoroutine(SwordSwing()); // swing sword
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) // if the sword hits something
    {
        if (other.gameObject.name == "Enemy(Clone)" || other.gameObject.name == "TutEnemy" || other.gameObject.name == "Gunman(Clone)" || other.gameObject.name == "Boss(Clone)")
        { // if the sword hits an enemy
            if (rotating == true) // and we are hitting
            {
                if(other.gameObject.name == "Gunman") // DO DAMAGE TO THE ENEMY, ITS DIFFERENT FOR EVERY TYPE
                {
                    gunmanScript = other.gameObject.GetComponent<Gunman>();
                    gunmanScript.health = gunmanScript.health - 50; // do damage to gunman and update health bar
                    gunmanScript.UpdateHealthBar();
                } 
                else if (other.gameObject.name == "Boss(Clone)")
                {
                    bossScript = other.gameObject.GetComponent<Boss>(); // do damage to boss
                    bossScript.TakeDamage(120);
                }
                else {
                    enemyScript = other.gameObject.GetComponent<Enemy>();
                    Debug.Log(enemyScript.health);
                    enemyScript.health = enemyScript.health - 50; // do damage to normal enemy and update health bar
                    enemyScript.UpdateHealthBar();
                }
            }
            
        }
        if (other.gameObject.name == "Friend") // if we hit kevin
        {
            if(rotating == true)
            {
                if(ouching == false) // say OWCH!
                {
                    StartCoroutine(OwchRoutine());
                }
            }
            
        }
    }

    IEnumerator SwordSwing() // swing the sword
    {
        swordAnim.Play("sword"); // play the animation
        yield return new WaitForSeconds(0.5f);
        swordAnim.Play("Idle");
        rotating = false;
    }

    IEnumerator OwchRoutine() // spawn in the owch text if we hit kevin
    {
        ouching = true;
        ouch.SetActive(true);
        Debug.Log("owching");
        StartCoroutine(owching.Remove());
        yield return new WaitForSeconds(2);
        ouch.SetActive(false);
        ouching = false;
    }
}
