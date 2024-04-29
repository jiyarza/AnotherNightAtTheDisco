using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    /// <summary>
    /// Utility class to manage structural elements like scene loading and global settings
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private static AudioSource[] audioSources;

        [SerializeField] private Texture2D _defaultCursor;

        public static Texture2D DefaultCursor => Instance._defaultCursor;
        public static Vector3 ScreenCenter => new(Screen.width / 2f, Screen.height / 2f, 0f);
        public static Vector3 WorldCenter => Camera.main.ScreenToWorldPoint(ScreenCenter);

        public static AudioSource[] AudioSources => audioSources;

        private static float defaultVolume = 1f;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                LoadAudioSources();
                if (audioSources.Length > 0)
                {
                    defaultVolume = audioSources[0].volume;
                }
                Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }

            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1.0f;
            }

        }

        /// <summary>
        /// Loads the scene specified by index
        /// </summary>
        /// <param name="scene"></param>
        public static void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        /// <summary>
        /// Quits the game and returns to desktop
        /// </summary>
        public static void QuitGame()
        {
            Application.Quit();
        }

        public static void SetGlobalVolume(float volume)
        {
            foreach (AudioSource source in audioSources)
            {
                source.volume = volume;
            }
        }

        public static void ResetGlobalVolume()
        {
            SetGlobalVolume(defaultVolume);
        }

        public static void StopAudioSources()
        {
            foreach (AudioSource source in audioSources)
            {
                if (source != null && source.isPlaying)
                    source.Stop();
            }
        }

        /// <summary>
        /// Returns an array with all audio sources in the scene
        /// </summary>
        /// <returns></returns>
        private static void LoadAudioSources()
        {
            audioSources = FindObjectsOfType<AudioSource>();
            Debug.Log($"Sources found:{audioSources.Length}");
        }
    }
}