using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnGame : MonoBehaviour
{
    PlayerConroller pc;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Restart); // when we click resstart
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restart scene (game)
    }
}
