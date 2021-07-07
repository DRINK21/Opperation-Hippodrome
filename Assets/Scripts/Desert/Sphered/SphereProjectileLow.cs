using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereProjectileLow : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;

    private Transform player;

    private Vector2 target;
    public LayerMask whatIsSolid;

    public int damage;
    public GameObject destroyEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        Invoke("DestroyProjectile", lifetime);
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        ;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); // Position to move projectile too
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid); // Creates raycast for the projectile 

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player Must Take Damage!");
                hitInfo.collider.GetComponent<PlayerControl>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}