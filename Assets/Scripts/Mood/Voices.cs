using Core.Audio;
using UnityEngine;

public class Voices : MonoBehaviour
{
    public AudioPlayer audioPlayer;
    public SFXSet voices;
    
    /// <summary>
    /// the interval to roll new voice is randomized around this value in seconds
    /// </summary>
    public float baseInterval = 5f;
    public float variation = 2.5f;
    public float probability = 0.5f;
    private float currentInterval = 0f;
    private float t0 = 0f;

    private void Start()
    {
        currentInterval = Random.value * baseInterval * variation;
        t0 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Global.IsInArcade)
        {
            if (Time.time - t0 > currentInterval)
            {
                Voice();
                currentInterval = Random.value * baseInterval * variation;
                t0 = Time.time;
            }
        }
    }

    private void Voice()
    {
        if (Random.value < probability) 
        {
            audioPlayer.PlayRandomPitch(voices);
        }
    }
}

