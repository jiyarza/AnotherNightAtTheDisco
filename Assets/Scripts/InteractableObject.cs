using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
    private Color color;

    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }

    public virtual void Contact()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public virtual void ContactLost()
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void Interact()
    {
        Debug.Log($"{this.name} Interacting");
    }
}
