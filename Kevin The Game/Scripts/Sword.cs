using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 400f;
    private Camera mainCamera;
    Stab stab;
    GameObject player;
    bool rotating;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        player = GameObject.Find("Player");
        stab = player.GetComponent<Stab>();
    }

    // Update is called once per frame
    void LateUpdate()
    {//
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); // get where the mouse is positioned
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength) && rotating == false) // if we arent hitting with the sword
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z)); // make the sword look at the mouse
        }
    }

    

}
