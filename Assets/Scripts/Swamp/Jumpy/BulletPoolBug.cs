using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolBug : MonoBehaviour
{
    public static BulletPoolBug bulletPoolInstanseBug;

    [SerializeField]
    private GameObject pooledBulletBug;
    private bool notEnoughBulletsInPoolBug = true;

    private List<GameObject> bulletsBug;

    private void Awake()
    {
        bulletPoolInstanseBug = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletsBug = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBullet()
    {
        if (bulletsBug.Count > 0) // checks if any bullets are in the pool
        {
            for (int i = 0; i < bulletsBug.Count; i++)
            {
                if (!bulletsBug[i].activeInHierarchy)
                {
                    return bulletsBug[i];
                }
            }
        }

        if (notEnoughBulletsInPoolBug) // if there arent enough we add bullets
        {
            GameObject bulBug = Instantiate(pooledBulletBug);
            bulBug.SetActive(false);
            bulletsBug.Add(bulBug);
            return bulBug;
        }
        return null; // if we cant do any of above
    }
}
