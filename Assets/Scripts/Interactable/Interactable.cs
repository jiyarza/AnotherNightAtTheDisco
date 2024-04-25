using UnityEngine;

public interface Interactable
{
    public enum InteractionType { HABLAR, JUGAR }
    void Contact();
    void ContactLost();
    void Interact();

    InteractionType Interaction();

    GameObject GameObject { get; }
    Entity entity { get; }
}