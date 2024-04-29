using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a list of clips and reproduction mode
/// </summary>
[System.Serializable]
public class PlayList
{
    public AudioClip[] clips;    
    private List<AudioClip> _availableClips;    
    private int _index = 0;

    public void Initialize()
    {    
        ResetAvailableClips();        
    }

    void ResetAvailableClips()
    {
        if (_availableClips == null)
            _availableClips = new List<AudioClip>();

        _availableClips.Clear();

        foreach (AudioClip clip in clips)
            _availableClips.Add(clip);
    }

    public AudioClip GetNextClip()
    {
        return clips[(_index++) % clips.Length];
    }

    public AudioClip GetRandomClip()
    {
        if (_availableClips == null || _availableClips.Count == 0)
            ResetAvailableClips();

        int rndIndex = Random.Range(0, _availableClips.Count - 1);
        AudioClip result = _availableClips[rndIndex];
        _availableClips.RemoveAt(rndIndex);

        return result;
    }
}
