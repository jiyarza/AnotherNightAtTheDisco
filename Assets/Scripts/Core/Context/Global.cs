using UnityEngine;
using Core.Gameplay;
public class Global : MonoBehaviour
{
    public static Global instance;
    public static GameValue<Interactable> contact;
    private static bool isInArcade = false;
    private static bool isInDialog = false;

    public static bool IsInDialog
    {
        get => isInDialog;
        set
        {
            isInDialog = value;
            if (value)
            {
                isInArcade = false;
            }            
        }
    }

    public static bool IsInArcade
    {
        get => isInArcade;
        set
        {
            isInArcade = value;
            if (value)
            {
                isInDialog = false;
            }
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            contact = new GameValue<Interactable>();
        }
        else
        {
            Destroy(this);
        }
    }

}
