using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameClock : MonoBehaviour
{
    /// <summary>
    /// Duration in seconds
    /// </summary>
    public float gameDuration = 240f;

    public static UnityEvent onTimeOver;

    private void OnEnable()
    {
        onTimeOver ??= new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clock());        
    }

    private IEnumerator Clock()
    {
        yield return new WaitForSeconds(gameDuration);
        onTimeOver?.Invoke();
    }
}
