using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owching : MonoBehaviour
{
    private bool ing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ing == false) // if it isnt already happening
        {
            StartCoroutine(Remove());
        }
        
    }

   public IEnumerator Remove() // deactivate after 2 seconds
    {
        ing = true;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        ing = false;
    }
}
