using TMPro;
using UnityEngine;
using Core.Gameplay;

public class InteractionClue : MonoBehaviour
{
    public static InteractionClue instance;

    public GameObject cluePanel;
    public TextMeshProUGUI clueText;
    public static Entity entity;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        cluePanel.SetActive(false);
        Global.contact.onValueChange.AddListener(InteractionPossible);
    }

    public void InteractionPossible(Interactable old, Interactable contact)
    {
        if (contact != null)
        {
            cluePanel.SetActive(true);
            clueText.text = $"{contact.Entity.displayName}\n[Pulsa espacio para {contact.InteractionType.displayName}]";
        } else
        {
            Hide();
        }
    }

    public static void Hide()
    {
        instance.cluePanel.SetActive(false);
        instance.clueText.text = "";
    }
}
