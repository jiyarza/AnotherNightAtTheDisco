using System.Collections.Generic;
using UnityEngine;

public class WallTransparency : MonoBehaviour
{
    public Transform player; // Referencia al transform del personaje jugador
    public Camera mainCamera; // Referencia a la cámara principal
    public LayerMask wallLayer; // Capa que contiene las paredes

    private Renderer wallRenderer; // Componente Renderer de la pared
    private Color originalColor; // Color original de la pared

    private List<Renderer> transparentWalls;

    private void Start()
    {
        transparentWalls = new List<Renderer>();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 direction = player.position - mainCamera.transform.position;

        if (Physics.Raycast(mainCamera.transform.position, direction, out hit, Mathf.Infinity, wallLayer))
        {
            if (hit.collider.gameObject == gameObject)
            {
                wallRenderer = hit.collider.GetComponent<Renderer>();
                originalColor = wallRenderer.material.color;
                Color transparentColor = originalColor;
                transparentColor.a = 0.1f; // 90% de transparencia

                wallRenderer.material.color = transparentColor;
                transparentWalls.Add(wallRenderer);
            }
            else
            {
                if (transparentWalls.Count > 0)
                {
                    foreach (Renderer r in transparentWalls)
                    {
                        Color color = r.material.color;
                        color.a = 1f;
                        r.material.color = color;
                    }
                    transparentWalls.Clear();
                }
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        // Obtener la posición inicial del rayo
        Vector3 origen = mainCamera.transform.position;

        // Calcular la dirección del rayo usando la rotación del objeto
        //Vector3 direccion = transform.forward;
        Vector3 direccion = player.position - mainCamera.transform.position;
        float longitud = Vector3.Distance(player.position, mainCamera.transform.position);

        // Dibujar el rayo
        Gizmos.DrawRay(origen, direccion * longitud);
    }
}
