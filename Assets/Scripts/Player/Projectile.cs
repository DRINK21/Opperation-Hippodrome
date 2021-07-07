using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public AudioSource ShootingEffect;
    public LayerMask whatIsSolid;

    public int damage;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        //ShootingEffect = GetComponent<AudioSource>();

        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            //ShootingEffect.Play();
            //if (Input.GetMouseButtonUp(0) == true)
            //{
            //    ShootingEffect.Stop();
            //}
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Must Take Damage!");
                hitInfo.collider.GetComponent<BirdMovement>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Swamp"))
            {
                Debug.Log("Swamp Enemy Must Take Damage!");
                hitInfo.collider.GetComponent<TreeMovement>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("MiniBoss"))
            {
                Debug.Log("MiniBoss Must Take Damage!");
                hitInfo.collider.GetComponent<BirdBehaviour>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Jumpy"))
            {
                Debug.Log("Jumpy Must Take Damage!");
                hitInfo.collider.GetComponent<BugMovement>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Desert"))
            {
                Debug.Log("Desert Boss Must Take Damage");
                hitInfo.collider.GetComponent<SphereMovement>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("DMini"))
            {
                Debug.Log("DMini Must Take Damage");
                hitInfo.collider.GetComponent<DMiniMovement>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("ZombieD"))
            {
                Debug.Log("Zombie Must Take Damage");
                hitInfo.collider.GetComponent<ZombieDMovement>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
//      transform.position += transform.up * speed * Time.deltaTime; Does same as line above 
    }
    
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
