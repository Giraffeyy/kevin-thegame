using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 10, -5); // camera offset
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset; // update the camera position
    }

    public void TurnAround()
    {
        offset = new Vector3(0, 10, 5); // cahnge the offset if we need the camera to be turned around
        transform.rotation = Quaternion.Euler(45, 180, 0);
    }
}
