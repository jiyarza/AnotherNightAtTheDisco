using UnityEngine;

namespace ArcadeGames.SpaceInvaders
{
    public class PlayerBullet : MonoBehaviour
    {
        public float speed = 150f;

        void Update()
        {
            if (Global.IsInArcade)
            {
                MoveUp();
            }
        }

        void MoveUp()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        void OnBecameInvisible()
        {
            Destroy(gameObject); // Destruir la bala al salir de la pantalla
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Enemy>())
            {
                Destroy(gameObject);
            }
        }
    }
}