using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeMovement : MonoBehaviour
{
    public Transform player;

    public Slider bossHealthBar;
    public float health;
    public static float bossHealth;

    public float startTimeBetweenShots;
    private float timeBetweenShots1;
    private float timeBetweenShots2;
    public GameObject TreeProjectile;
    public GameObject EndLevel;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthBar.value = health;
        bossHealth = health;

       /* if (bossHealth > 71)
        {
            if (timeBetweenShots1 <= 0)
            {
                Instantiate(TreeProjectile, transform.position, Quaternion.identity); // creates projectile from BossProjectile1
                timeBetweenShots1 = startTimeBetweenShots; // Limits boss to shooting only a certain amount of times
            }
            else
            {
                timeBetweenShots1 -= Time.deltaTime; // Counts down timer before boss can shoot again
            }
        }
        if (bossHealth < 71)
        {
            if (timeBetweenShots2 <= 0)
            {
                Instantiate(TreeProjectileLow, transform.position, Quaternion.identity); // creates projectile from BossProjectile1
                timeBetweenShots2 = startTimeBetweenShots; // Limits boss to shooting only a certain amount of times
            }
            else
            {
                timeBetweenShots2 -= Time.deltaTime; // Counts down timer before boss can shoot again
            }
        }*/

        if (health <= 0)
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            Score.BossKill = Score.BossKill + 500;
            Destroy(gameObject);
            EndLevel.SetActive(true);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Boss Health is " + health);
    }
}
