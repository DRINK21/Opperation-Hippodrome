using UnityEngine;

public class FireBullets : MonoBehaviour
{
    // Phase 1 
    public int bulletsAmount;
    public float startAngle;
    public float endAngle;
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
        
        if (BirdMovement.bossHealth >= 71 || BirdBehaviour.bossHealth >= 71) // Stage 1
        {
            if (stage1counter == true)
            {
                InvokeRepeating("Fire", 0.1f, 1.5f);
                stage1counter = false;
            }
        }
        if ((BirdMovement.bossHealth >= 31 && BirdMovement.bossHealth < 71) || (BirdBehaviour.bossHealth >= 31 && BirdBehaviour.bossHealth < 71)) // Stage 2
        {
            if (stage2counter == true)
            {
                CancelInvoke("Fire");
                InvokeRepeating("Fire", 0.1f, 1f);
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
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BirdBullet>().SetMoveDirection(bulletDir);

            angle += bulletSpread;
        }
    }
}

