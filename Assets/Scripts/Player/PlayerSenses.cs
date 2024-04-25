using UnityEngine;

public class PlayerSenses : MonoBehaviour
{
    public float rayDistance = 2.5f;

    // Spherecast
    public float sphereRadius = 1f; // Radio del SphereCast
    public float maxDistance = 2.5f; // Distancia máxima del SphereCast

    void Update()
    {
        SenseRay();

        /*
        SenseSphere();
        if (Global.contact.Value == null)
        {
            SenseRay();
        } */
    }        

    private void SenseRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Global.contact.Value = interactable;
            } else
            {
                InteractionClue.Hide();
            }
        }
    }


    private void SenseSphere()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, maxDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Global.contact.Value = interactable;
            }
        }
    }

    void OnDrawGizmos()
    {
        // Dibujar el rayo en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + transform.forward * maxDistance, sphereRadius);
    }
}