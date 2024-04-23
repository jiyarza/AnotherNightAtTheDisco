using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del personaje

    void Update()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Calcular la velocidad de movimiento
        Vector3 moveVelocity = moveDirection * speed;

        // Aplicar el movimiento al personaje
        transform.Translate(moveVelocity * Time.deltaTime, Space.World);
    }
}
