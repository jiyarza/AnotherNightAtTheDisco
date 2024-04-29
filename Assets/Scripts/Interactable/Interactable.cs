using UnityEngine;

namespace Core.Gameplay
{
    public interface Interactable
    { 
        void Contact();
        void ContactLost();
        void Interact();

        InteractionType InteractionType { get; }

        GameObject GameObject { get; }
        Entity Entity { get; }
    }
}