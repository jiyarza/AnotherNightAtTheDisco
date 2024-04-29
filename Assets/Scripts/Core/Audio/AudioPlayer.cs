using System.Collections;
using System.Linq;
using UnityEngine;


namespace Core.Audio
{
    /// <summary>
    /// Utility class to play random clips from a list defined in a SFXSetSO ScriptableObject.
    /// It can be at random pitch also to add more variety.
    /// </summary>
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _fadeTime;
        public bool random = false;
        public bool autoplay = false;
        public PlayList playList;

        private float _initialVolume;
        private bool isStopped = false;

        public bool IsPlaying => _audioSource.isPlaying;

        public float Volume
        {
            get => _audioSource.volume;
            set { _audioSource.volume = value; }
        }

        private void OnEnable()
        {
            if (_audioSource == null)
            {
                throw new MissingReferenceException($"{nameof(AudioPlayer)} is missing one reference to {nameof(AudioSource)}");
            }
        }

        private void Start()
        {
            _initialVolume = Volume;

            if (playList == null)
                playList = new PlayList();

            if (autoplay && playList.clips.Count() > 0)
            {
                playList.Initialize();
                Play(playList);
            }
        }

        public void Play()
        {
            if (playList != null && playList.clips.Length > 0)
                Play(playList);
        }

        public void Play(PlayList playList)
        {
            isStopped = false;
            StartCoroutine(CRPlay(playList));
        }

        private IEnumerator CRPlay(PlayList playList)
        {
            while (!isStopped && isActiveAndEnabled)
            {
                if (random)
                {
                    Play(playList.GetRandomClip());
                }
                else
                {
                    Play(playList.GetNextClip());
                }
                yield return new WaitWhile(() => _audioSource.isPlaying);
            }
        }

        public void Play(SFXSet sfx)
        {
            isStopped = false;
            if (sfx)
            {
                _audioSource.PlayOneShot(GetRandomAudioClip(sfx));
            }
        }

        public void Play(AudioClip clip)
        {
            isStopped = false;
            _audioSource.PlayOneShot(clip);
        }

        public void Play(AudioClip clip, float volume)
        {
            isStopped = false;
            float vol = _audioSource.volume;
            _audioSource.volume = volume;
            _audioSource.PlayOneShot(clip);
            StartCoroutine(ResetVolume(vol));
        }


        public void Play(SFXSet sfx, float volume)
        {
            isStopped = false;
            float vol = _audioSource.volume;
            _audioSource.volume = volume;
            Play(sfx);
            StartCoroutine(ResetVolume(vol));
        }

        // Resets volume back to default once finished playing current clip
        IEnumerator ResetVolume(float volume)
        {
            yield return new WaitUntil(() => !IsPlaying);
            _audioSource.volume = volume;
        }


        public void PlayRandomPitch(SFXSet sfx)
        {
            if (sfx && sfx.AudioClips.Length > 0)
            {
                isStopped = false;
                _audioSource.pitch = Random.Range(0.8f, 1.2f);
                _audioSource.PlayOneShot(GetRandomAudioClip(sfx));
                _audioSource.pitch = 1f;
            }
            else
            {
                Debug.Log($"ERROR: SFXSet {sfx.name} is empty");
            }
        }

        public void Stop()
        {
            if (_audioSource && _audioSource.isPlaying)
                _audioSource.Stop();
            // Has been stopped from code
            isStopped = true;
        }

        private AudioClip GetRandomAudioClip(SFXSet sfx)
        {
            if (sfx)
            {
                return sfx.AudioClips[Random.Range(0, sfx.AudioClips.Length)];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Fade in sound
        /// </summary>
        /// <returns></returns>
        IEnumerator FadeIn()
        {
            float elapsedTime = 0f;
            while (elapsedTime < _fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                float value = Mathf.Lerp(0f, _initialVolume, elapsedTime / _fadeTime);
                Volume = value;

                yield return null;
            }
        }

    }
}