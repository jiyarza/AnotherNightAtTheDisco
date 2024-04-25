using UnityEngine;

namespace ArcadeGames.SpaceInvaders
{
    public class PlayerBullet : MonoBehaviour
    {
        public float speed = 100f;

        void Update()
        {
            MoveUp();
        }

        void MoveUp()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (IsOutOfScreen())
            {
                Destroy(gameObject);
            }
        }

        bool IsOutOfScreen()
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            return viewPos.y > 1f;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Enemy"))
                Destroy(gameObject);
        }
    }
}