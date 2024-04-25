using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private static DialogController instance;
    private Dialog dialog;
    private int index = 0;

    public Image Portrait;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Text;
    public CharacterController player;
    public GameObject dialogRootPanel;

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

    IEnumerator PlayDialogCoroutine()
    {
        index = 0;
        while (ShowEntry() >= 0)
        {                        
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return new WaitForSeconds(2.5f);
            //yield return new WaitWhile(() => Input.GetKeyDown(KeyCode.Space));
            //yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        }            
//        }
        yield return new WaitForSeconds(1f);
        dialogRootPanel.SetActive(false);
        //player.enabled = true;
    }

    private int ShowEntry()
    {
        if (dialog != null && index < dialog.entries.Length)
        {
            Name.text = dialog.entries[index].entity.displayName;
            Text.text = dialog.entries[index].text;
            Portrait.sprite = dialog.entries[index].entity.icon;
            index++;
            return index;
        } else
        {
            ResetDialog();
            //player.enabled = true;
            //Global.gameState.Value = Global.GameState.DISCO;
            return -1;
        }
    }

    public void PlayDialog(Dialog dialog)
    {
        this.dialog = dialog;
        //player.enabled = false;
        dialogRootPanel.SetActive(true);
        StartCoroutine(PlayDialogCoroutine());
    }

    private void ResetDialog()
    {
        dialog = null;
        Name.text = "";
        Text.text = "";
        Portrait.sprite = null;
        index = 0;
        dialogRootPanel.SetActive(false);
    }
}
