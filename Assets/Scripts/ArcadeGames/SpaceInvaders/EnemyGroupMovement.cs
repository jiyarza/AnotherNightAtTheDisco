using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    public float lateralSpeed = 3f; // Velocidad lateral del grupo
    public float lateralDistance = 530f;
    public float jumpDistance = 20f; // Distancia del salto
    public LayerMask collisionLayer; // Capa de colisi�n para detectar el l�mite de la pantalla

    private bool movingRight = true; // Direcci�n actual del movimiento
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {        
        // Movimiento lateral constante
        Vector3 movement = Vector3.right * (movingRight ? 1 : -1) * lateralSpeed * Time.deltaTime;
        transform.Translate(movement);

        float distance = transform.position.x - initialPosition.x; 

        if ( Mathf.Abs(distance) > lateralDistance)
        {
            // Realizar el salto hacia abajo
            transform.Translate(Vector3.down * jumpDistance);

            // Cambiar de direcci�n lateral
            movingRight = !movingRight;
        }
    }

}
