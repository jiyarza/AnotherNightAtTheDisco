using ArcadeGames.SpaceInvaders;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public GameObject explosionPrefab;
    public static float shootProbability = 0.2f;
    public static float shootInterval = 3f;
    public bool isDead = false;
    private static Collider2D lastCollision = null;
    private RectTransform rect;
    private static float lastShootTime;
    public static int bulletCount = 0;
    private static int maxBulletCount = 5;
    private static int enemiesCount = 0;
    private Canvas parentCanvas;

    public static UnityEvent onAllEnemiesDestroyed;

    private void Awake()
    {
        onAllEnemiesDestroyed ??= new UnityEvent();
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        lastShootTime = Time.time;
        enemiesCount = FindObjectsOfType<Enemy>().Length;
        parentCanvas = FindParentCanvas();
    }

    void Update()
    {
        if (Global.IsInArcade)
        {
            if (!isDead)
            {
                CheckShoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerBullet>())
        {
            Die();
            enemiesCount--;
            Debug.Log($"Enemies left = {enemiesCount}");
            if (enemiesCount == 0)
            {
                CallStaticEvent();               
            }
        }
        else if (collision.CompareTag("BoundingBox"))
        {
            if (lastCollision != collision)
            {
                EnemyGroupMovement.Jump();
                lastCollision = collision;
            }
        }
    }

    private static void CallStaticEvent()
    {
        onAllEnemiesDestroyed?.Invoke();
    }

    private void Die()
    {
        isDead = true;
        Explode();
        EnemyGroupMovement.lateralSpeed += 8f;
    }

    void CheckShoot()
    {
        bulletCount = FindObjectsOfType<EnemyBullet>().Length;

        if (bulletCount < maxBulletCount && Time.time - lastShootTime > shootInterval)
        {
            float randomValue = Random.value;
            if (randomValue < shootProbability)
            {
                ShootBullet();
                lastShootTime = Time.time;
            }
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, Vector2.zero, Quaternion.identity, parentCanvas.transform);
        bullet.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(0f, 0.5f) * rect.rect.size + rect.anchoredPosition;
        bullet.transform.SetParent(parentCanvas.transform);
    }

    private void Explode()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GameObject explosion = Instantiate(explosionPrefab, Vector2.zero, Quaternion.identity, transform);
        explosion.transform.SetParent(transform.parent);
        explosion.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition;
        Destroy(gameObject, 2f);
    }

    private Canvas FindParentCanvas()
    {
        Canvas canvas = null;

        Transform parent = transform.parent;

        while (parent != null)
        {
            canvas = parent.GetComponent<Canvas>();
            if (canvas != null)
            {                
                Debug.Log("Se encontró el componente Canvas en el GameObject padre: " + canvas.gameObject.name);
                return canvas;
            }
            parent = parent.parent;
        }

        if (canvas == null)
        {
            Debug.Log("No se encontró el componente Canvas en ninguno de los GameObjects padres.");
        }

        return canvas;
    }
}