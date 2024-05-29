using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class Gunman : MonoBehaviour
{
    private float timer = 5;
    public float maxHealth = 100;
    public float health = 100;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;
    Transform target;
    private Rigidbody rb;
    Vector3 moveDirection;
    GameObject player;
    Transform look;
    Transform door;
    public Slider slider;
    public ParticleSystem deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
        look = GameObject.Find("Armsword").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer(); // shoot at the player

        if(health <= 0) // if we die
        {
            Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
            Debug.Log("no hp");
            Destroy(gameObject);
        }

    }

    void ShootAtPlayer()
    {
        
        transform.LookAt(target); // look aat the player
        bulletTime -= Time.deltaTime; // cooldown
        if (bulletTime > 0) return;

        bulletTime = timer;
        timer = Random.Range(3, 7); // get a random cooldown
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject; // add bullet
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed); // shoot bullet
        Destroy(bulletObj, 5f); // destroy after 5 seconds
    }

    public void UpdateHealthBar() // update health bar
    {
        slider.value = health / maxHealth;
    }

    
}
