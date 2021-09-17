using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDamageSound : MonoBehaviour
{
    [SerializeField] private AudioSource _brokenSound;
    [SerializeField] private AudioSource _destroySound;

    private void OnEnable()
    {
        BrickState.OnBrickDamaged += PlayBrokenSound;
        BrickState.OnBrickDestroyed += PlayDestroySound;
    }

    private void OnDisable()
    {
        BrickState.OnBrickDamaged -= PlayBrokenSound;
        BrickState.OnBrickDestroyed -= PlayDestroySound;
    }

    private void PlayBrokenSound()
    {
        _brokenSound.Play();
    }

    private void PlayDestroySound()
    {
        _destroySound.Play();
    }
}
