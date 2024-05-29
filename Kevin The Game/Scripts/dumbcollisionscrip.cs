using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dumbcollisionscrip : MonoBehaviour
{
    public GameObject lava;
    private GameObject player;
    private CameraController cc;
    private SpawnManager sm;
    private GameObject kevin;
   
    PlayerConroller pc;
    private DialogueScript dh;
    private GameObject talk3;
    private GameObject talk4;
    // Start is called before the first frame update
    void Start()
    {

        // initialize variables

        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        cc = GameObject.Find("Main Camera").GetComponent<CameraController>();
        dh = GameObject.Find("DialogueManager").GetComponent<DialogueScript>();
        kevin = GameObject.Find("Friend");
        talk3 = sm.talk3;
        talk4 = sm.talk4;
        player = GameObject.Find("PlayerCharacter");
        pc = player.GetComponent<PlayerConroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door")) // if we hit door
        {
            leave(); // send away
        }

        if(other.CompareTag("dumbcollision")) // if we try to go outo f bounds
        {
            pc.TakeDamage(10);
            leave(); // send away
            StartCoroutine(LavaRoutine());
            
        }

        if(other.CompareTag("juice")) // if we get the juice
        {
            cc.TurnAround(); // turn around camera
            talk3.SetActive(false);
            talk4.SetActive(true);
            kevin.transform.position = new Vector3(talk4.transform.position.x, kevin.transform.position.y, talk4.transform.position.z); // move kevin
            pc.turnedAround = true;
            Destroy(other.gameObject);
        }
        
        // IF WE GET IN TALKING RANGE

        if(other.gameObject.name == "Talk1")
        {
            dh.StartDH(1);
        }

        if(other.gameObject.name == "Talk2")
        {
            dh.StartDH(2);
        }
        if(other.gameObject.name == "Talk3")
        {
            dh.StartDH(3);
        }
        if(other.gameObject.name == "Talk4")
        {
            dh.StartDH(4);
        }
    }

    // IF WE LEAVE TALKING RANGE

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Talk1")
        {
            dh.StopDH(1);
        }
        if(other.gameObject.name == "Talk2")
        {
            dh.StopDH(2);
        }
        if(other.gameObject.name == "Talk3")
        {
            dh.StopDH(3);
        }
    }

    // SEND AWAY PLAYER

    private void leave()
    {
        if(sm.wavingTwo == true & sm.wavingThree == false) // depending where the player is in the game, it will send them to a different point
        {
            Vector3 teleposition = new Vector3(0, player.transform.position.y, 60);
            player.transform.position = teleposition;
        } else if (sm.wavingThree == true)
        {
            Vector3 teleposition = new Vector3(0, player.transform.position.y, 100);
            player.transform.position = teleposition;
        } else {
            Vector3 teleposition = new Vector3(0, player.transform.position.y, 0);
            player.transform.position = teleposition;
        }
    }

    private IEnumerator LavaRoutine() // if you step in the lava tell you to stop
    {
        lava.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        lava.gameObject.SetActive(false);
    }
}
