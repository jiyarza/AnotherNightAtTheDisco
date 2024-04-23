using UnityEngine;

public class NPC : MonoBehaviour, Interactable
{
    [Tooltip("The message to display when interacting with this object")]
    public string[] conversation = { "Interact with this object", "Second message" };

    public void Interact()
    {
        TriggerConversation();
    }

    private void TriggerConversation()
    {

    }
}
