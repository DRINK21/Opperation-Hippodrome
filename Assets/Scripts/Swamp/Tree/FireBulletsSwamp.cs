using UnityEngine;

public class FireBulletsSwamp : MonoBehaviour
{
    // Phase 1 
    public int bulletsAmount;
    public int bulletsAmount2;
    public float startAngle;
    public float endAngle;
    public float startAngle2;
    public float endAngle2;
    private Vector2 bulletMoveDirection;
    private bool stage1counter = true;
    private bool stage2counter = true;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (TreeMovement.bossHealth >= 71) // Stage 1
        {
            if (stage1counter == true)
            {
               InvokeRepeating("Fire", 0.1f, 2f);
                stage1counter = false;
            }
        }
        if (TreeMovement.bossHealth >= 31 && TreeMovement.bossHealth < 71) // Stage 2
        {
            if (stage2counter == true)
            {
                CancelInvoke("Fire");
                InvokeRepeating("Fire", 2f, 1.8f);
                InvokeRepeating("Fire2", 2f, 1.8f);
                stage2counter = false;
            }
        }
    }

    private void Fire()
    {
        float bulletSpread = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            // End Point
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 120f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 120f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<TreeBullet>().SetMoveDirection(bulletDir);

            angle += bulletSpread;
        }
    }
    private void Fire2()
    {
        float bulletSpread2 = (endAngle2 - startAngle2) / bulletsAmount2;
        float angle2 = startAngle;

        for (int i = 0; i < bulletsAmount2 + 1; i++)
        {
            // End Point
            float bulletDirX = transform.position.x + Mathf.Cos((angle2 * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Sin((angle2 * Mathf.PI) / 180f);

            Vector3 bulletMoveVector2 = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir2 = (bulletMoveVector2 - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<TreeBullet>().SetMoveDirection2(bulletDir2);

            angle2 += bulletSpread2;
        }
    }
}

