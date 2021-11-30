using System.Collections;
using UnityEngine;

namespace ArkanoidColorVoxels
{
    [RequireComponent(typeof(AudioSource))]
    public class GameMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip musicIntro;
        [SerializeField] private AudioClip musicLoop;

        private AudioSource _audioSource;
        
        public delegate void StartMusic();
        public static event StartMusic OnStartMusicCompleted;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            PlayIntro();
        }

        private void PlayIntro()
        {
            _audioSource.clip = musicIntro;
            _audioSource.Play();
            StartCoroutine(PlayLoopMusic());
        }
        
        private IEnumerator PlayLoopMusic()
        {
            yield return new WaitForSeconds(_audioSource.clip.length);
            OnStartMusicCompleted?.Invoke();
            _audioSource.clip = musicLoop;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}

