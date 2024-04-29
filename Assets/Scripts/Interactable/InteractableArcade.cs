using UnityEngine;
using Core.Gameplay;

public class InteractableArcade : InteractableObject, Interactable
{
    public ArcadeGameController gameController;

    public override void Interact()
    {
        base.Interact();
        gameController.EnterArcade();
    }
}
