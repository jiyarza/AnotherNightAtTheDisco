using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ArcadeGames.SpaceInvaders
{    
    public class PlayerShipController : MonoBehaviour
    {        
        public float speed = 100f;
        public float minX, maxX;
        private bool isDead = false;
        public GameObject explosionPrefab;
        public static UnityEvent onPlayerShipDestroyed;

        private void Awake()
        {
            onPlayerShipDestroyed ??= new UnityEvent();
        }

        private void OnDisable()
        {
//            onPlayerShipDestroyed.RemoveAllListeners();
        }

        void Update()
        {
            if (Global.IsInArcade)
            {

                if (!isDead)
                {
                    float horizontalInput = Input.GetAxis("Horizontal");
                    Vector3 currentPosition = transform.position;

                    currentPosition.x += horizontalInput * speed * Time.deltaTime;
                    currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

                    transform.position = currentPosition;
                }
            }
        }

        void Start()
        {
            SetMovementLimits();
        }

        void SetMovementLimits()
        {
            RectTransform panelRect = transform.parent.GetComponent<RectTransform>();
            float panelWidth = panelRect.rect.width;
            minX = panelRect.position.x - panelWidth / 2f;
            maxX = panelRect.position.x + panelWidth / 2f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Global.IsInArcade)
            {
                if (collision.CompareTag("Enemy"))
                {
                    Die();
                }
            }
        }

        public void Die()
        {
            isDead = true;
            Explode();
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
            Invoke("GameOver", 3f);
        }

        public void GameOver()
        {
            onPlayerShipDestroyed?.Invoke();
        }

    }

}
