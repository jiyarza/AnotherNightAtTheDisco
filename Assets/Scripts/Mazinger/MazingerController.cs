using UnityEngine;

public class MazingerController : MonoBehaviour
{
    [SerializeField] GameObject mazingerPose;
    [SerializeField] GameObject mazingerDance;
    [SerializeField] bool danceUnlocked;

    private void Start()
    {
        if (danceUnlocked)
        {
            Unlock();
        } else
        {
            ArcadeGameController.onVictory.AddListener(Unlock);
            Debug.Log("ArcadeGameController.onVictory.AddListener(Unlock);");
        }        
    }

    private void OnDisable()
    {
        //ArcadeGameController.onVictory.RemoveListener(Unlock);
    }

    public void Lock()
    {
        Debug.Log("Locked");
        danceUnlocked = false;
        mazingerPose.SetActive(true);
        mazingerDance.GetComponent<Animator>().enabled = false;
        mazingerDance.SetActive(false);
    }

    public void Unlock()
    {
        Debug.Log("Unlocked");
        danceUnlocked = true;
        mazingerPose.SetActive(false);
        mazingerDance.GetComponent<Animator>().enabled = true;
        mazingerDance.SetActive(true);
    }

}
