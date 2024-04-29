using UnityEngine;

namespace Core.Gameplay
{
    [CreateAssetMenu(fileName = "NewInteractionType", menuName = "AnotherNightAtTheDisco/Interaction Type")]
    public class InteractionType : ScriptableObject
    {
        public enum Type { HABLAR, JUGAR }

        public Type type;
        public string displayName;
        public AudioClip audioClip;        
    }
}