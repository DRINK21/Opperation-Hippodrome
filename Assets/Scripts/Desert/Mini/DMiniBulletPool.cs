using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMiniBulletPool : MonoBehaviour
{
    public static DMiniBulletPool bulletPoolInstanseDM;

    [SerializeField]
    private GameObject pooledBulletDM;
    private bool notEnoughBulletsInPoolDM = true;

    private List<GameObject> bulletsDM;

    private void Awake()
    {
        bulletPoolInstanseDM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletsDM = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBullet()
    {
        if (bulletsDM.Count > 0) // checks if any bullets are in the pool
        {
            for (int i = 0; i < bulletsDM.Count; i++)
            {
                if (!bulletsDM[i].activeInHierarchy)
                {
                    return bulletsDM[i];
                }
            }
        }

        if (notEnoughBulletsInPoolDM) // if there arent enough we add bullets
        {
            GameObject bulDM = Instantiate(pooledBulletDM);
            bulDM.SetActive(false);
            bulletsDM.Add(bulDM);
            return bulDM;
        }
        return null; // if we cant do any of above
    }
}
