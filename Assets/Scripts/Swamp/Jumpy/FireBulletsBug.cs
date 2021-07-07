using UnityEngine;

public class FireBulletsBug : MonoBehaviour
{
    // Phase 1 
    public int bulletsAmountBug;
    public float startAngleBug;
    public float endAngleBug;
    private Vector2 bulletMoveDirectionBug;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0.1f, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Fire()
    {
        float bulletSpread = (endAngleBug - startAngleBug) / bulletsAmountBug;
        float Bugangle = startAngleBug;

        for (int i = 0; i < bulletsAmountBug + 1; i++)
        {
            // End Point
            float BUGbulletDirX = transform.position.x + Mathf.Sin((Bugangle * Mathf.PI) / 180f);
            float BUGbulletDirY = transform.position.y + Mathf.Cos((Bugangle * Mathf.PI) / 180f);

            Vector3 BUGbulletMoveVector = new Vector3(BUGbulletDirX, BUGbulletDirY, 0f);
            Vector2 BUGbulletDir = (BUGbulletMoveVector - transform.position).normalized;

            GameObject bulBug = BulletPoolBug.bulletPoolInstanseBug.GetBullet();
            bulBug.transform.position = transform.position;
            bulBug.transform.rotation = transform.rotation;
            bulBug.SetActive(true);
            bulBug.GetComponent<BugBullet>().SetMoveDirection(BUGbulletDir);

            Bugangle += bulletSpread;
        }
    }
}

