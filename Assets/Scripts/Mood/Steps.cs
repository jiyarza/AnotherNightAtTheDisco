using Core.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class Steps : MonoBehaviour
{
    public AudioPlayer player;
    public SFXSet steps;

    public void Play()
    {
        player.PlayRandomPitch(steps);
    }
}
