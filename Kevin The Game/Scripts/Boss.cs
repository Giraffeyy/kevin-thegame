using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : MonoBehaviour
{

    //variables

    private Transform look;
    private bool canAttack = true;
    private int randomAttack;
    private Rigidbody rb;
    private Transform tp;
    public GameObject cubePrefab;
    private GameObject bossSpawn;
    public Slider bossBar;
    public float health = 2000f;
    private float maxHealth = 2000f;
    public GameObject warningPlate;
    public GameObject downPrefab;
    private GameObject downSpawner;
    public GameObject warningPlateSpawner;
    private Animator bossAnim;
    private bool spinning;
    PlayerConroller pc;
    private GameObject juice;
    private GameObject kevin;
    private GameObject talk4;
    private GameObject talk3;
    SpawnManager sm;
    private TextMeshProUGUI o4;
    private TextMeshProUGUI o1;
    private TextMeshProUGUI o2;
    private TextMeshProUGUI oK;
    private TextMeshProUGUI o3;
    public ParticleSystem deathParticle;


    // Start is called before the first frame update
    void Start()
    {

        //initialize all variables

        kevin = GameObject.Find("Friend");
        juice = GameObject.Find("JUICE");
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        juice = sm.juice;
        talk3 = sm.talk3;
        talk4 = pc.talk4;
        o4 = sm.o4;
        o3 = sm.o3;
        o1 = sm.o1;
        o2 = sm.o2;
        oK = sm.oK;
        bossAnim = GetComponent<Animator>();
        warningPlateSpawner = GameObject.Find("WarningPlateSpawner");
        downSpawner = GameObject.Find("DownSpawner");
        bossBar = GameObject.Find("BossBar").GetComponent<Slider>();
        bossSpawn = GameObject.Find("BossSpawn");
        look = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("BossSpawn").transform.position;//teleport to the boss spawn when the boss is spawned
        transform.LookAt(look);//look at player
        StartCoroutine(BossAttack());//start attacks
    }

    IEnumerator BossAttack()
    {
        if(canAttack == true)//if the boss can attack
        {
            canAttack = false;
            randomAttack = Random.Range(0, 4);//get a randodm attack
            if(randomAttack == 1)//if the attack is #1
            {
                bossAnim.enabled = true;
                bossAnim.Play("SpinAttack");//play the spin attack animation
                spinning = true;//tell the script that we are using the spin attack
            }
            else if(randomAttack == 2)
            {
                Debug.Log("atk2");
                StartCoroutine(ShootCube());//shoot cubes
                
            } else if (randomAttack == 3)
            {
                Debug.Log("atk3");
                Instantiate(downPrefab, downSpawner.transform.position, downPrefab.transform.rotation); // add the falling plate
                Instantiate(warningPlate, warningPlateSpawner.transform.position, warningPlate.transform.rotation); // add the warning for the falling plate

            } /*else
            {
                canAttack = true;//otherwise reset attack
            }*/
            yield return new WaitForSeconds(3f);
            bossAnim.enabled = false;//after waiting we can tell the boss that we are no longer attacking and use the cooldown
            spinning = false;
            canAttack = true;
        }
        
    }

    public void TakeDamage(float damage)//when the boss is hit
    {
        health = health - damage; // take damage
        bossBar.value = health / maxHealth; // update the boss health bar
        if(health <= 0) // if the boss dies
        {

            // change the objective text

            o4.gameObject.SetActive(true);
            o1.gameObject.SetActive(false);
            o2.gameObject.SetActive(false);
            oK.gameObject.SetActive(false);
            o3.gameObject.SetActive(false);

            Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
            Destroy(gameObject); // destroy the boss
            sm.bossKilled = true;//tell the spawn manager that the boss is killed
            bossBar.gameObject.SetActive(false);//remove the boss health
            juice.SetActive(true);//spawn the juice
        }
    }

    IEnumerator ShootCube()//shoot the cubes
    {
        Instantiate(cubePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(cubePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(cubePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter(Collider other)//when we hit something
    {
        if(spinning == true)//if we are doing the spin attack
        {
            if(other.gameObject.name == "Player")//if its player
            {
                pc.TakeDamage(5);//do damage to the player
            }
        }
    }
}
