using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startDistance;
    public float startTimeBetweenShots;
    private float timeBetweenShots;
    public GameObject BossProjectile1;
    private Transform player;
    public GameObject deathEffect;

    public Slider bossHealthBar;
    public float health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        bossHealthBar.value = health;

        if (player != null) // once player dies we good
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < startDistance)
            { // Moves towards player if the boss is too far away
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance && Vector2.Distance(transform.position, player.position) < startDistance)
            { // Stays in the same spot if the player is within the distance parameters
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance && Vector2.Distance(transform.position, player.position) < startDistance)
            { // Moves backwards if the player moves too close
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            // Boss Shooting
            if (timeBetweenShots <= 0 && Vector2.Distance(transform.position, player.position) < startDistance)
            {
                Instantiate(BossProjectile1, transform.position, Quaternion.identity); // creates projectile from BossProjectile1
                timeBetweenShots = startTimeBetweenShots; // Limits boss to shooting only a certain amount of times
            }
            else
            {
                timeBetweenShots -= Time.deltaTime; // Counts down timer before boss can shoot again
            }
        }
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Boss Health is " + health);
    }
}