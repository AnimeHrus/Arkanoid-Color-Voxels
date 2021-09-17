using System.Collections;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _startMusic;
    [SerializeField] private AudioSource _backGroundMusic;
    public delegate void StartMusic();
    public static event StartMusic OnStartMusicCompleted;

    private void Start()
    {
        _startMusic.Play();
        StartCoroutine(PlayLoopMusic());
    }

    private IEnumerator PlayLoopMusic()
    {
        yield return new WaitForSeconds(_startMusic.clip.length);
        OnStartMusicCompleted?.Invoke();
        _backGroundMusic.Play();
    }
}
