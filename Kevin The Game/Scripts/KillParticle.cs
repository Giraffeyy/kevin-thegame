using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f); // destroy particle after 1 second
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}