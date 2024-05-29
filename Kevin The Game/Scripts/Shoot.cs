using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera mainCamera;
    PlayerConroller pc;
    public float power;
    private bool pCool = true;
    public GameObject arm1;
    private GameObject arm1pos;
    private float bulletTime;
    public GameObject enemyBullet;
    private GameObject spawnPoint;
    private GameObject arrowprop;
    public bool canShoot = true;
    public TextMeshProUGUI helpText1;
    public TextMeshProUGUI helpText2;
    public TextMeshProUGUI helpText3;
    public TextMeshProUGUI helpText4;
    public Slider slider;
    private float fillTime;
    public bool sYes;
    public float arrowDamage;
    Arrow arrow;

    // Start is called before the first frame update
    void Start()
    {

        // initialize variables

        helpText2.gameObject.SetActive(false);
        helpText3.gameObject.SetActive(false);
        helpText4.gameObject.SetActive(false);
        arrowprop = GameObject.Find("arrowprop");
        arm1pos = GameObject.Find("armpos");
        arm1pos.SetActive(false);
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        spawnPoint = GameObject.Find("arrowspawn");
    }

    // Update is called once per frame
    void Update()
    { 
        if(canShoot == true) // if we can shoot
        {
            helpText4.gameObject.SetActive(false);
            if(Input.GetKey("space")) // while we are holding space
            {
                if(pc.swordTrue == false)
                {
                    sYes = true; // set shooting status to true
                    arrowprop.SetActive(true); // add prop arrow
                    StartCoroutine(PowerUp()); // power up bow
                }

            }

            if(Input.GetKeyUp("space")) // when we stop charging
            {
                sYes = false;
                canShoot = false;
                arrowprop.SetActive(false); // remove prop, set shooting to no and prevent us from shooting again
                arm1.transform.position = arm1pos.transform.position;
                Shooting();// shoot the arrow
            }
        }
        
    }

    IEnumerator PowerUp() // when we are powering up the bow
    {
        if(pCool == true && power <= 29)    // if we arent at max power and we arent already charged
        {
            helpText2.gameObject.SetActive(true);
            helpText1.gameObject.SetActive(false); // make the text say charging
            arm1.transform.Translate(Vector3.back * 0.01f);
            arm1.transform.Translate(Vector3.left * 0.005f); // move the arm
            pCool = false;
            arrowDamage = arrowDamage + 7;
            power += 2; // add power
            yield return new WaitForSeconds(0.05f); // cooldown
            pCool = true;
            slider.value = power/30; // change the slider value
        }
        if(power >29) // if we are fully charged
        {
            helpText3.gameObject.SetActive(true); // make the text tell us to shoot
            helpText2.gameObject.SetActive(false);
            
        }
    }

    private void Shooting() // when we shoot the bow
    {
        helpText2.gameObject.SetActive(false); // change the text
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject; // add the arrow
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); // make a ray to show where we are showing with the mouse
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);
            Debug.Log(pointToLook);
            bulletObj.transform.LookAt(new Vector3(pointToLook.x, bulletObj.transform.position.y    , pointToLook.z)); // force the arrow to look at where we areclicking
        }
        bulletRig.AddForce(bulletRig.transform.forward * (power*100)); // shoot bullet
        power = 0;
        arrow = GameObject.Find("Arrow_01").GetComponent<Arrow>();
        arrow.damage = arrowDamage;
        arrowDamage = 0;
        Destroy(bulletObj, 2f);// destroy after 2 seconds
        StartCoroutine(ShootingCooldown());

    }

    IEnumerator ShootingCooldown() // start cooldown
    {
        helpText4.gameObject.SetActive(true); // add cooldown text
        helpText3.gameObject.SetActive(false);

        slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, fillTime);     // cooldown slider  
 
        fillTime += 2f * Time.deltaTime;

        yield return new WaitForSeconds(1f); // wait
        canShoot = true;
        helpText1.gameObject.SetActive(true); // change text
    }
}
