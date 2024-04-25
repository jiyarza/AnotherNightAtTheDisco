using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public GameObject explosionPrefab;
    public float shootProbability = 0.05f;
    public float shootInterval = 3f;

    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time;
    }

    void Update()
    {
        CheckShoot();
    }

    void CheckShoot()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            float randomValue = Random.value;
            if (randomValue <= shootProbability)
            {
                SpawnEnemyBullet();
            }
            lastShootTime = Time.time;
        }
    }

    void SpawnEnemyBullet()
    {
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
