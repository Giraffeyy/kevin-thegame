using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutEnemy : MonoBehaviour
{
    Vector3 mainPos;
    // Start is called before the first frame update
    void Start()
    {
        mainPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != mainPos) // MAKE THE ENEMY STAY STILL
        {
            transform.position = mainPos;
        }
    }
}
