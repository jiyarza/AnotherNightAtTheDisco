using Core.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private static DialogController instance;
    private DialogPlayer dialogPlayer;    

    public Image Portrait;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Text;
    public CharacterController player;
    public GameObject dialogRootPanel;
    public AudioClip showEntry;
    private float delayTime = 0.2f;
    private float lastDialogTime = 0f;

    [SerializeField] private AudioPlayer audioPlayer;

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

    private void Update()
    {
        if (Global.IsInDialog)
        {
            if (Input.GetKeyDown(KeyCode.Space)
                && (Time.time - lastDialogTime > delayTime))
            {
                PlaySfx(showEntry);
                ShowEntry();                
            }
        }
    }

    private void ShowEntry()
    {
        if (dialogPlayer == null)
            throw new MissingReferenceException(nameof(dialogPlayer));

        DialogEntry entry = dialogPlayer.Next;
        Debug.Log($"Index={dialogPlayer.Index}");
        if (entry)
        {
            Name.text = entry.entity.displayName;
            Text.text = entry.text;
            Portrait.sprite = entry.entity.icon;
            lastDialogTime = Time.time;
        }
        else
        {
            Name.text = "";
            Text.text = "";
            Portrait.sprite = null;
            dialogRootPanel.SetActive(false);
            Global.IsInDialog = false;
        }
    }

    public void PlayDialog(Dialog dialog)
    {
        if (!Global.IsInArcade)
        {
            Global.IsInDialog = true;
            dialogPlayer = new(dialog);
            dialogRootPanel.SetActive(true);
            ShowEntry();
        }
    }

    private void PlaySfx(AudioClip clip)
    {
        if (clip != null && audioPlayer != null)
        {
            audioPlayer.Play(clip);
        }
    }
}
