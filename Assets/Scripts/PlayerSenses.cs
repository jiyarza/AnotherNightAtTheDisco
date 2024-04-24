using UnityEngine;

public class PlayerSenses : MonoBehaviour
{
    public float rayDistance = 2.5f;
    public LayerMask interactableLayer;
    private Interactable contact;

    private void Start()
    {
        contact = null;
    }

    void Update()
    {
        RaycastHit hit;

        // Lanzar un rayo hacia adelante desde la posición del jugador
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, interactableLayer))
        {
            // Verificar si el rayo ha chocado con un objeto interactable
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {                
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    // Realizar acciones con el objeto interactable más cercano
                    interactable.Interact();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Dibujar el rayo en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}