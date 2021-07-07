using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DMiniMovement : MonoBehaviour
{
    public Transform player;

    public Slider DMiniHealthBar;
    public float health;

    public float jumpSpeed;
    public float stoppingDistance;
    public float startDistance;
    public float jumpTime;
    private float jumpTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DMiniHealthBar.value = health;

        if (player != null)
        {
            if (jumpTimer <= 0 && Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < startDistance)
            { // Moves towards player if the boss is too far away
                transform.position = Vector2.MoveTowards(transform.position, player.position, jumpSpeed * Time.deltaTime);
            }
            else if (jumpTimer <= 0 && Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) < startDistance)
            { // Stays in the same spot if the player is within the distance parameters
                transform.position = this.transform.position;
                jumpTimer = jumpTime;
            }
            else
            {
                jumpTimer -= Time.deltaTime;
            }
        }

        if (health <= 0)
        {
            //  Instantiate(deathEffect, transform.position, Quaternion.identity);
            Score.BossKill = Score.BossKill + 100;
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Boss Health is " + health);
    }

}
