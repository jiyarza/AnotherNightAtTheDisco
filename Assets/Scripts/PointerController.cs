using UnityEngine;

public class PointerController : MonoBehaviour
{
    public LayerMask interactableLayer; // Capa de los objetos interactuables
    public float interactionDistance = 5f; // Distancia máxima de interacción

    void Update()
    {
        // Lanzar un rayo desde la posición del ratón en la pantalla
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // Verificar si el objeto con el que colisiona es interactuable
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Ejecutar la acción de interacción
                interactable.Interact();
            }
        }
    }
}
