using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public Slider hpSlider;
    private float speed = 10;
    public GameObject player;
    public float health = 100;
    public float maxHealth = 100;
    private Rigidbody playerRb;
    private GameObject armsword;
    private GameObject armbow;
    private GameObject bowmodel;
    private GameObject swordmodel;
    public bool swordTrue = true;
    private bool changeCooldown = false;
    public Slider weaponSlider;
    private Shoot shootScript;
    public GameObject titleScreen;
    public GameObject deathScreen;
    public bool turnedAround = false;
    public GameObject talk4;
    Stab stabScript;

    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        weaponSlider.gameObject.SetActive(false);
        player = GameObject.Find("Player");
        armsword = GameObject.Find("Armsword");
        armbow = GameObject.Find("armbow");
        bowmodel = GameObject.Find("propbow");
        swordmodel = GameObject.Find("PropSword");
        swordmodel.SetActive(false);
        armbow.SetActive(false);
        stabScript = GameObject.Find("Sword").GetComponent<Stab>();
        shootScript = armbow.GetComponent<Shoot>();
        hpSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        player.transform.position = transform.position;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (turnedAround == false) // change movement depending on if camerea is flipped or not
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        } else if (turnedAround == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed * verticalInput);
            transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);
        }
        

        if (player.transform.position.y > 1.7) // make sure the player doesnt fly away
        {
            player.transform.position = new Vector3 (transform.position.x, 1, transform.position.z);
        } else if (player.transform.position.y < 1.2) {
            player.transform.position = new Vector3 (transform.position.x, 1, transform.position.z);
        }

        if(Input.GetKeyDown("e")) // if we hit e then change wepon
        {
            ChangeWeapon();
        }
    }

    public void TakeDamage(float damage) // if we take damage
    {

        health = health - damage;
        Debug.Log("Enemy did " + damage + "damage, now at " + health + "hp. Slider value at " + health / maxHealth);
        hpSlider.value = health / maxHealth; // add damage
        if(health <= 0) // if we die then game over
        {
            GameOver();
        }
    }

    private void GameOver() // game over deletes the player and shows the death screen
    {
        deathScreen.SetActive(true);
        Destroy(gameObject);
    }

    private void ChangeWeapon()
    {
        if(shootScript.sYes == false) // if we arent shooting
        {
            if(stabScript.rotating == false) // if we arent hititng
            {
                if(changeCooldown == false) // if the cooldown isnt active
                {
                    if (swordTrue == true) // if we have the swordo ut
                    {
                        armbow.SetActive(true); // activaate the bow
                        swordmodel.SetActive(true);
                        weaponSlider.gameObject.SetActive(true); // add the bow overlay
                        armsword.SetActive(false); // remove the sword
                        bowmodel.SetActive(false);
                        swordTrue = false;
                        shootScript.canShoot = true; // allow the script to shoot
                    } 
                    else if (swordTrue == false) // if we have the bow out
                    {
                        armbow.SetActive(false);
                        swordmodel.SetActive(false); // deativate the bow
                        armsword.SetActive(true); // add the sword
                        weaponSlider.gameObject.SetActive(false); // remove the overlay
                        bowmodel.SetActive(true);
                        swordTrue = true; // allow us to hit
                    }
                }
            }
        }
        
        
        WeaponCooldown(); // start weapon cooldown
    }

    IEnumerator WeaponCooldown() // cooldown for switching
    {
        changeCooldown = true;
        yield return new WaitForSeconds(5);
        changeCooldown = false;
    }

    public void LaunchGame() // when we hit play on the game
    {
        hpSlider.gameObject.SetActive(true);
        titleScreen.SetActive(false);
    }
}
