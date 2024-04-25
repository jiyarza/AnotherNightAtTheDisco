using UnityEngine;

public class InteractableArcade : InteractableObject, Interactable
{
    public ArcadeGameController gameController;
    //public GameObject arcadeRoot;
    //public AudioSource audioSource;
    //public Camera arcadeCamera;
    //private Camera[] allCameras;
    private CharacterController player;

    private void Start()
    {
        player = FindFirstObjectByType<CharacterController>();
    }

    public override void Interact()
    {
        base.Interact();
        EnterArcadeMachine();
    }

    private void EnterArcadeMachine()
    {
        player.gameObject.SetActive(false);
        gameController.EnterArcade();
    }

    public void ExitArcadeMachine()
    {
        gameController.ExitArcade();
        player.gameObject.SetActive(true);
    }

    public override Interactable.InteractionType Interaction()
    {
        return Interactable.InteractionType.JUGAR;
    }

}
