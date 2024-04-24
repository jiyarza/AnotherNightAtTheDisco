using UnityEngine;
using UnityEngine.PlayerLoop;


[CreateAssetMenu(fileName = "NewDialog", menuName = "AnotherNightAtTheDisco/Dialog")]
public class Dialog : ScriptableObject
{
    public DialogEntry[] entries;
    
}
