using Core;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject root;
    [SerializeField] Button quitButton;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        root.SetActive(false);
        quitButton.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausar el tiempo del juego
        root.SetActive(true); // Mostrar el panel de pausa
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        root.SetActive(false); // Ocultar el panel de pausa
    }

    public void Quit()
    {
        GameManager.LoadScene(0);
    }
}
