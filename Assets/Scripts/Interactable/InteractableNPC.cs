using UnityEngine;
public class InteractableNPC : InteractableObject
{
    public Dialog dialog;
    private bool dialogPlayed = false;

    public override void Interact()
    {
        base.Interact();
        if (dialog == null)
        {
            Debug.Log($"{this.entity.displayName} interaction dialog is null");
            throw new MissingReferenceException(nameof(dialog));
        }
        if (!dialogPlayed)
        {
            DialogController.Instance.PlayDialog(dialog);
            dialogPlayed = true;
        }        
        if (dialogPlayed && dialog.Repeatable)
        {
            dialogPlayed = false;
            // should play again on the next interaction
        }
    }
}
