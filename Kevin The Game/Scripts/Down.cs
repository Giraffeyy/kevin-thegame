using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{

    PlayerConroller pc;

    // Start is called before the first frame update
    void Start()
    {

        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();//gets player controller
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* Time.deltaTime * 20);//bring down
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.name == "Player")//if it collides with player
        {
            pc.TakeDamage(10);//do damage
        }
    }
}
