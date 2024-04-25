using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public Canvas canvas;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
            nextFireTime = Time.time + fireRate;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootBullet()
    {
        RectTransform rect = transform.GetComponent<RectTransform>();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        RectTransform bulletRect = bullet.GetComponent<RectTransform>();
        if (bulletRect != null)
        {
            bulletRect.SetParent(rect, false);

        }
    }
}

