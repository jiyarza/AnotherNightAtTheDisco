using UnityEngine;

public class InteractableNPC : MonoBehaviour, Interactable
{
    [Tooltip("The message to display when interacting with this object")]
    public string[] conversation = { "Interact with this object", "Second message" };

    private Color color;

    private void Start()
    {
        color = GetComponent<Renderer>().material.color;
    }


    public void Contact()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void ContactLost()
    {
        GetComponent<Renderer>().material.color = color;
    }
    public void Interact()
    {
        TriggerConversation();
    }

    private void TriggerConversation()
    {

    }


}
