using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    PlayerConroller pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        Destroy(gameObject, 2f); // delete in 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 20); // move forward
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") // if it hits player do damage
        {
            pc.TakeDamage(4);
        }
    }
}
