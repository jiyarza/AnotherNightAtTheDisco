using UnityEngine;

public class InteractableNPC : InteractableObject
{
    PlayerController player;
    public Dialog dialog;

    private void Start()
    {
    }

    public override void Interact()
    {
        if (dialog != null)
        {
            DialogController.Instance.PlayDialog(dialog);
        }
    }

}
