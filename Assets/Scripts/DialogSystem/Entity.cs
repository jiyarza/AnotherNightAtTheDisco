using UnityEngine;

[CreateAssetMenu(fileName = "NewEntity", menuName = "AnotherNightAtTheDisco/Entity")]
public class Entity : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public AudioClip sfx;
}
