using UnityEngine;
using Core.Gameplay;
public class PlayerSenses : MonoBehaviour
{
    public float rayDistance = 1.5f;

    void Update()
    {
        if (!Global.IsInDialog && !Global.IsInArcade)
            SenseRay();
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
                Global.contact.Value = null;         
            }
        }
        else
        {
            Global.contact.Value = null;
            InteractionClue.Hide();
        }
    }

    void OnDrawGizmos()
    {
        // Dibujar el rayo en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}