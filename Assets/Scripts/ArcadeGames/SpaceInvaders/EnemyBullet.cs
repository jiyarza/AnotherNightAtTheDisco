using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 23f;

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            Destroy(gameObject);
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destruir la bala al salir de la pantalla
    }
}