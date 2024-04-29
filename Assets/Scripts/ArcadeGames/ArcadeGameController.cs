using UnityEngine;
using UnityEngine.UI;
using Core;
using Core.Audio;
using ArcadeGames.SpaceInvaders;
using TMPro;
using UnityEngine.Events;

public class ArcadeGameController : MonoBehaviour
{
    [SerializeField] private AudioPlayer discoAudioPlayer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MazingerController mazingerController;

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
    public TextMeshProUGUI gameover;
    public static UnityEvent onVictory; 

    private void Awake()
    {
        onVictory ??= new UnityEvent();
    }

    void Start()
    {
        startGame.onClick.AddListener(StartGame);
        exitGame.onClick.AddListener(ExitArcade);
        quitGame.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {        
        onVictory.RemoveAllListeners();
        discoAudioPlayer.Stop();
    }

    public void EnterArcade()
    {
        Global.IsInArcade = true;
        InteractionClue.Hide();        
        player.gameObject.SetActive(false);
        arcadeRoot.SetActive(true);
        ShowMenu();
        GameManager.StopAudioSources();
        discoAudioPlayer.Stop();
        audioSource.Play();
        PlayerShipController.onPlayerShipDestroyed.AddListener(Defeat);
        Debug.Log("PlayerShipController.onPlayerShipDestroyed.AddListener(Defeat);");
        Enemy.onAllEnemiesDestroyed.AddListener(Victory);
        Debug.Log("Enemy.onAllEnemiesDestroyed.AddListener(Victory);");

    }

    public void ExitArcade()
    {
        new WaitForSeconds(0.25f);
        player.gameObject.SetActive(true);        
        audioSource.Stop();
        discoAudioPlayer.Play();
        arcadeRoot.SetActive(false);
        Global.IsInArcade = false;
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

    public void Victory()
    {
        Debug.Log("Victory");
        gameover.text = "Victory";
        gameover.gameObject.SetActive(true);
        onVictory?.Invoke();
        Invoke("QuitGame", 5f);        
    }

    public void Defeat()
    {
        gameover.text = "Game Over";
        Invoke("QuitGame", 5f);        
    }


    public void QuitGame()
    {
        gameover.gameObject.SetActive(false);
        ShowMenu();
    }
}
