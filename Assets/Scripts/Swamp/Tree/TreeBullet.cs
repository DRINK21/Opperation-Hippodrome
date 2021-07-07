using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector2 moveDirection2;
    public float bulletSpeed;
    public float bulletSpeed2;

    private void OnEnable()
    {
        Invoke("Destroy", 5.5f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TreeMovement.bossHealth > 70)
        {
            transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
        }
        if (TreeMovement.bossHealth < 71)
        {
            transform.Translate(moveDirection * bulletSpeed2 * Time.deltaTime);
            transform.Translate(moveDirection2 * bulletSpeed2 * Time.deltaTime);
        }
    }

    public void SetMoveDirection(Vector2 dir)
    {
        // Uses FireBullet to create the direction that the bullet will travel
        moveDirection = dir;
    }

    public void SetMoveDirection2(Vector2 dir2)
    {
        moveDirection2 = dir2;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();        // When object is destroyed it cancels invoke 
    }
}


