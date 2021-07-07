using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    Vector2 movement;

    public Animator animator;
    public float health;
    public Slider playerHealthBar;
    public Transform enemy;
    public Transform swamp;
    public GameObject deathEffect;
    public GameObject hitEffect;
    public TextMeshProUGUI healthText;

    public GameObject LightDrop;
    public AudioSource DeadSoundEffect;
    public bool countdown = false;

    void Start()
    {
     //   anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        swamp = GameObject.FindGameObjectWithTag("Swamp").transform;
        DeadSoundEffect = GetComponent<AudioSource>();

    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        
        playerHealthBar.value = health;
        healthText.text = "Health: "+ health.ToString();

        if (rb.velocity.magnitude == 0)
        {
            if (countdown == false)
            {
                countdown = true;
                StartCoroutine(HealthRegen());
            }
        }
        if (health <= 0)
        {
            StartCoroutine(TimeCountdown());
            SceneManager.LoadScene("GameOver");

            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Score.totalScore <= 0)
            {
                Debug.Log("you need more score to place a light");
            }
            else
            {
                Instantiate(LightDrop, transform.position, Quaternion.identity);
                Score.lightDrop -= 10;
                Debug.Log("Light has been placed, 10 score has been taken away");

            }
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health is " + health);
        animator.SetTrigger("isHurt");
        StartCoroutine(TimeCountdown());
        animator.SetTrigger("isIdle");
        animator.SetTrigger("isMove");
    }
    IEnumerator TimeCountdown()
    {
        yield return new WaitForSeconds(1);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Detected");
        GameObject e = Instantiate(hitEffect) as GameObject;
        e.transform.position = transform.position;
        other.gameObject.SetActive(false);
        TakeDamage(10);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

   IEnumerator HealthRegen()
    {
        if(health < 100)
        {
            health++;
            Debug.Log("health is now at" + health);
        }
        yield return new WaitForSeconds(1);
        countdown = false;
    }

   
} 
