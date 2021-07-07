using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolD : MonoBehaviour
{
    public static BulletPoolD bulletPoolInstanse;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstanse = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0) // checks if any bullets are in the pool
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool) // if there arent enough we add bullets
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null; // if we cant do any of above
    }
}
