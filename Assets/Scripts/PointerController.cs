using UnityEngine;

public class PointerController : MonoBehaviour
{
    public LayerMask interactableLayer; // Capa de los objetos interactuables
    public float interactionDistance = 5f; // Distancia m�xima de interacci�n

    void Update()
    {
        // Lanzar un rayo desde la posici�n del rat�n en la pantalla
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // Verificar si el objeto con el que colisiona es interactuable
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Ejecutar la acci�n de interacci�n
                interactable.Interact();
            }
        }
    }
}
