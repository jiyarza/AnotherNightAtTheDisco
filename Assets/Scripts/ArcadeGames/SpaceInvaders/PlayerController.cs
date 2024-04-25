using UnityEngine;

namespace ArcadeGames.SpaceInvaders
{
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public float minX, maxX;

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 currentPosition = transform.position;

            currentPosition.x += horizontalInput * speed * Time.deltaTime;
            currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

            transform.position = currentPosition;
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
    }

}
