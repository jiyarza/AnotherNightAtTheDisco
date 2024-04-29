using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "AnotherNightAtTheDisco/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] DialogEntry[] entries;
    [SerializeField] bool repeatable;

    public DialogEntry[] Entries => entries;
    public bool Repeatable => repeatable;
}
