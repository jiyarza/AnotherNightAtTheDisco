using UnityEngine;
using UnityEngine.UI;

public class ArcadeGameController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource discoAudioSource;
    public Button startGame;
    public Button exitGame;
    [Tooltip("Panel to hide/show the arcade UI")]
    public GameObject arcadeRoot;
    [Tooltip("GameObject to hide/show the Menu")]
    public GameObject menuRoot;
    [Tooltip("GameObject to hide/show the arcade gameplay")]
    public GameObject gameplayRoot;
    [Tooltip("Quit gameplay and return to arcade main menu")]
    public Button quitGame;
    public CharacterController player;

    void Start()
    {
        startGame.onClick.AddListener(StartGame);
        exitGame.onClick.AddListener(ExitArcade);
        quitGame.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        audioSource.Stop();
    }

    public void EnterArcade()
    {
        InteractionClue.Hide();
        player.gameObject.SetActive(false);
        arcadeRoot.SetActive(true);
        ShowMenu();
        GameManager.StopAudioSources();
        audioSource.Play();
    }

    public void ExitArcade()
    {
        new WaitForSeconds(0.25f);
        player.gameObject.SetActive(true);
        audioSource.Stop();
        discoAudioSource.Play();
        arcadeRoot.SetActive(false);
    }

    public void ShowMenu()
    {
        gameplayRoot.SetActive(false);
        menuRoot.SetActive(true);
    }

    public void ShowGamePlay()
    {
        gameplayRoot.SetActive(true);
        menuRoot.SetActive(false);
    }

    public void StartGame()
    {
        ShowGamePlay();
    }

    public void QuitGame()
    {
        ShowMenu();
    }
}
