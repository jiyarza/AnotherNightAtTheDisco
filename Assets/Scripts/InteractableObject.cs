using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
    public Entity entity;
    public Color highlightColor = Color.yellow;
    private Color color;

    public GameObject GameObject => gameObject;

    Entity Interactable.entity => entity;

    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }

    public virtual void Contact()
    {
        GetComponent<Renderer>().material.color = highlightColor;
    }

    public virtual void ContactLost()
    {
        GetComponent<Renderer>().material.color = color;
    }

    public virtual void Interact()
    {
        Debug.Log($"{this.name} Interacting");
    }
}
