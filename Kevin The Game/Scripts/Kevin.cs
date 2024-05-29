using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kevin : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;//get player
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);//look at player
    }
}
