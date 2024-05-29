using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    PlayerConroller pc;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Starting); //make the start button
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Starting() // when we hit the start button, start the game
    {
        pc.LaunchGame();
    }
}
