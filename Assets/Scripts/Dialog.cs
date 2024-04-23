using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDialog", menuName = "AnotherNightAtTheDisco/Dialog")]
public class Dialog : ScriptableObject
{
    public DialogEntry[] entries;
}
