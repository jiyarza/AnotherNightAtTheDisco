using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    private static EnemyGroupMovement instance;
    public static float lateralSpeed = 40f; // Velocidad lateral del grupo
    public float jumpDistance = 20f; // Distancia del salto
    public static bool movingRight = true; // Dirección actual del movimiento

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {        
        // Movimiento lateral constante
        Vector3 movement = Vector3.right * (movingRight ? 1 : -1) * lateralSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public static void Jump()
    {
        // Realizar el salto hacia abajo
        instance.transform.Translate(Vector3.down * instance.jumpDistance);

        // Cambiar de dirección lateral
        movingRight = !movingRight;
    }
}
