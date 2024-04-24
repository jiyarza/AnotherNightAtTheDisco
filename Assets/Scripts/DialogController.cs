using System.Collections;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private static DialogController instance;
    private Dialog dialog;
    private int index = 0;

    public Sprite Portrait;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Text;
    public CharacterController player;


    public static DialogController Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Global.contact.onValueChange.AddListener(OnContact);
        player = FindFirstObjectByType<CharacterController>();
        ResetDialog();
    }

    IEnumerator PlayDialogCoroutine()
    {
        while (Global.gameState.Value.Equals(Global.GameState.DIALOG))
        {
            if (ShowEntry() >= 0)
            {
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            }
            yield return null;
        }
    }

    private int ShowEntry()
    {
        if (index < dialog.entries.Length)
        {
            Name.text = dialog.entries[index].entity.displayName;
            Text.text = dialog.entries[index].text;
            Portrait = dialog.entries[index].entity.icon;
            index++;
            return index;
        } else
        {
            ResetDialog();
            player.enabled = true;
            Global.gameState.Value = Global.GameState.NORMAL;
            return -1;
        }
    }

    public void OnContact(Interactable old, Interactable contact)
    {
        if (contact != null)
        {
            Name.text = contact.entity.displayName;
        } else
        {
            Name.text = "";
        }
    }

    public void PlayDialog(Dialog dialog)
    {
        if (Global.gameState.Value == Global.GameState.NORMAL)
        {
            ResetDialog();
            this.dialog = dialog;
            Global.gameState.Value = Global.GameState.DIALOG;
            player.enabled = false;
            StartCoroutine(PlayDialogCoroutine());
        }
    }

    private void ResetDialog()
    {
        dialog = null;
        Name.text = "";
        Text.text = "";
        Portrait = null;
        index = 0;
    }
}
