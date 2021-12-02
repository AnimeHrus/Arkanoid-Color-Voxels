using UnityEngine;

namespace ArkanoidColorVoxels
{
	[RequireComponent(typeof(AudioSource))]
	public class BrickSound : MonoBehaviour
	{
		[SerializeField] private AudioClip damageSound;
		[SerializeField] private AudioClip destroySound;
		
		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			_audioSource.clip = damageSound;
		}

		private void OnEnable()
		{
			Brick.OnBrickDamage += PlayDamageSound;
			Brick.OnBrickDestroy += PlayDestroySound;
		}

		private void OnDisable()
		{
			Brick.OnBrickDamage -= PlayDamageSound;
			Brick.OnBrickDestroy -= PlayDestroySound;
		}
		
		private void PlayDamageSound()
		{
			_audioSource.clip = damageSound;
			_audioSource.Play();
		}
		
		private void PlayDestroySound()
		{
			_audioSource.clip = destroySound;
			_audioSource.Play();
		}
	}
}