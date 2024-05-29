using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject talking;
    public GameObject dialogue1;
    public GameObject dialogueHelper;
    private SpawnManager sm;
    private bool inRange;
    private int dia;
    private int dia1level = 0;
    private int dia2level = 0;
    private int dia3level;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public TextMeshProUGUI d;
    public TextMeshProUGUI d2;
    public GameObject endScreen;
    public TextMeshProUGUI o1;
    public TextMeshProUGUI o2;
    public TextMeshProUGUI o3;
    public TextMeshProUGUI o4;
    public TextMeshProUGUI oK;
    private bool b;

    
    // Start is called before the first frame update
    void Start()
    {

        // set objective

        o1.gameObject.SetActive(false);
        o2.gameObject.SetActive(false);
        o3.gameObject.SetActive(false);
        o4.gameObject.SetActive(false);

        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")) // when we talk
        {
            if(inRange == true) // if we are in range
            {
                if(dia == 1) // if its the first talking point
                {
                    Debug.Log("dia1");
                    if(dia1level == 0)
                    {
                        DialogueOne(); // first dialogue
                    }
                    else if(dia1level == 1)
                    {
                        d.gameObject.SetActive(false);
                        d2.gameObject.SetActive(true);
                        dia1level = 2;
                    }
                    else if (dia1level == 2)
                    {
                        talking.SetActive(false);
                        dialogue1.SetActive(false);
                        dia1level = 0;
                    }
                }
                if(dia == 2) // if its the second talking point
                {
                    if(dia2level == 0)
                    {
                        DialogueTwo(); // second dialogue
                    }
                    else if (dia2level == 1)
                    {
                        talking.SetActive(false);
                        dialogue2.SetActive(false);
                        dia1level = 2;
                    }
                }
                if(dia == 3) // if its the third talking point
                {
                    if(dia3level == 0)
                    {
                        DialogueThree(); // third dialogue
                    }
                    else if (dia3level == 1)
                    {
                        talking.SetActive(false);
                        dialogue3.SetActive(false);
                        dia3level = 0;
                        sm.SpawnBoss();
                    }
                }
                if(dia == 4) // if its the end of the game
                {
                    endScreen.SetActive(true); // end the game
                }
            } else if (inRange == false)
            {
                if (b == true)
                {
                    talking.SetActive(false);
                    dialogue3.SetActive(false);
                    dia3level = 0;
                    sm.SpawnBoss(); 
                } else {
                    dia3level = 0;
                    dialogue3.SetActive(false);
                }

                dia1level = 0;
                dialogue1.SetActive(false);
                dia2level = 0;
                dialogue2.SetActive(false);
                talking.SetActive(false);
            }
        }
    }

    public void DialogueOne()
    {

        // set objective

        o1.gameObject.SetActive(true);
        oK.gameObject.SetActive(false);
        o2.gameObject.SetActive(false);
        o3.gameObject.SetActive(false);
        o4.gameObject.SetActive(false);
        talking.SetActive(true);
        dialogue1.SetActive(true);
        dia1level = 1;
    }

    private void DialogueTwo()
    {

        // set objective
        
        o2.gameObject.SetActive(true);
        oK.gameObject.SetActive(false);
        o1.gameObject.SetActive(false);
        o3.gameObject.SetActive(false);
        o4.gameObject.SetActive(false);
        talking.SetActive(true);
        dialogue2.SetActive(true);
        dia2level = 1;
    }

    private void DialogueThree()
    {

        // set objective

        o3.gameObject.SetActive(true);
        oK.gameObject.SetActive(false);
        o1.gameObject.SetActive(false);
        o2.gameObject.SetActive(false);
        o4.gameObject.SetActive(false);
        talking.SetActive(true);
        dialogue3.SetActive(true);
        dia3level = 1;
    }

    public void StartDH(int lol)
    {
        
        //when we enter the talking range

        dialogueHelper.SetActive(true);
        dia = lol;
        inRange = true;
    }

    public void StopDH(int lol)
    {

        //when we exit the talking range
        if (dia == 3)
        {
            b = true;
        } else
        {
            b = false;
        }
        dialogueHelper.SetActive(false);
        dia = 0;
        inRange = false;
    }
}
