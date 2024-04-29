using UnityEngine;

namespace Core.Audio
{
    /// <summary>
    /// Scriptable object that allows defining sets of audio clips to be used by the monobehaviours.
    /// This way the audio clips instances are shared, saving memory.
    /// </summary>
    [CreateAssetMenu(fileName = "SFXSet", menuName = "Scriptable Objects/SFX Set")]
    public class SFXSet : ScriptableObject
    {
        [SerializeField] private AudioClip[] _audioClips;

        public AudioClip[] AudioClips => _audioClips;
    }
}