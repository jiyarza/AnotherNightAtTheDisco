using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global instance;
    public static GameValue<Interactable> contact;

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
