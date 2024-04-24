using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogEntry", menuName = "AnotherNightAtTheDisco/Dialog Entry")]
public class DialogEntry : ScriptableObject
{
    public Entity entity;
    [TextArea] public string text;
}
