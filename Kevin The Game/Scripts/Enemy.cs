using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyDamage;
    public float maxHealth = 100;
    public float health;
    public Slider slider;
    [SerializeField] float moveSpeed = 10f;
    Rigidbody rb;
    Transform target;
    Vector3 moveDirection;
    public bool canTakeDamage = true;
    PlayerConroller pc;
    public ParticleSystem deathParticle;

    private void Awake()
    {
        pc = GameObject.Find("PlayerCharacter").GetComponent<PlayerConroller>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target) // if the player
        {
            Vector3 direction = (target.position - transform.position).normalized;// set the direction towards the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
            Quaternion rotationAngle = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
            rb.rotation = rotationAngle; // set the rotation
            moveDirection = direction; // move direction
            transform.LookAt(target); // look at player
        }

        if(transform.position.y < 1.0f) // make sure the enemy doesnt fly away
        {
            transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
        } else if (transform.position.y > 1.5f)
        {
            transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
        }

        if(health <= 0) // if the enemy dies
        {
            Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
            Debug.Log("no hp");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(target) // move the enemy towards the player
        {
            rb.velocity = new Vector3(moveDirection.x, transform.position.y, moveDirection.z) * moveSpeed;
        }
    }   

    public void UpdateHealthBar() // update hte health bar
    {
        slider.value = health / maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") // when we hit hte player
        {
            if(canTakeDamage == true)
            {
                canTakeDamage = false;
                pc.TakeDamage(enemyDamage); // do some damage, but only if it isnt on cooldown
                StartCoroutine(Damage());
            }
            
        }
    }

    IEnumerator Damage() // damage cooldown
    {
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
}