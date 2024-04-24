using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global instance;
    public static GameValue<Interactable> contact;
    public static GameValue<GameState> gameState;

    public enum GameState { NORMAL, DIALOG, ARCADE }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        contact = new GameValue<Interactable>();
        gameState = new GameValue<GameState>();
        gameState.Value = GameState.NORMAL;        
    }

}
