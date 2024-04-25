using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button newGame;
    public Button credits;
    public Button exitGame;
    public GameObject creditsPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(NewGame);
        credits.onClick.AddListener(Credits);
        exitGame.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditsPanel.SetActive(false);
        }
    }

    private void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Credits()
    {
        creditsPanel.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
