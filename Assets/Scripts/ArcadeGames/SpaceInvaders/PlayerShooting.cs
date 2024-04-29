using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Canvas canvas;
    public float fireRate = 0.75f;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private float nextFireTime;
    private float lapsedTime;
    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        nextFireTime = 0;
    }

    void Update()
    {
        if (Global.IsInArcade)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
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
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, Vector2.zero, Quaternion.identity, transform);
        bullet.transform.SetParent(transform.parent);
        bullet.GetComponent<RectTransform>().anchoredPosition = 
            new Vector2(0f, 0.5f) * rect.rect.size + rect.anchoredPosition;

        PlaySfx();
    }

    void PlaySfx()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}

