using UnityEngine;

public interface Interactable
{
    void Contact();
    void ContactLost();
    void Interact();

    GameObject GameObject { get; }
    Entity entity { get; }
}