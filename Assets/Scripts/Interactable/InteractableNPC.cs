using UnityEngine;

public class InteractableNPC : InteractableObject
{
    public Dialog dialog;

    public override void Interact()
    {
        base.Interact();
        if (dialog != null)
        {
            DialogController.Instance.PlayDialog(dialog);
        } 
        else 
        {
            Debug.Log($"{this.entity.displayName} dialog is null");
        }

    }

    public override Interactable.InteractionType Interaction() 
    {
        return Interactable.InteractionType.HABLAR;
    }

}
