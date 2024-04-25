using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, Interactable
{    
    public Entity entity;
    public GameObject GameObject => gameObject;

    Entity Interactable.entity => entity;

    public virtual void Contact()
    {
        Global.contact.Value = this;
        DialogController.Instance.Name.text = entity.displayName;
        DialogController.Instance.Text.text = "";
    }

    public virtual void ContactLost()
    {
        Global.contact.Value = null;
        DialogController.Instance.Name.text = "";
        DialogController.Instance.Text.text = "";
    }

    public virtual void Interact()
    {
        InteractionClue.Hide();
        Debug.Log($"{this.name} Interacting");
    }

    public abstract Interactable.InteractionType Interaction();
}
