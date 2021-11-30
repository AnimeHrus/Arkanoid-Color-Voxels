using UnityEngine;

namespace ArkanoidColorVoxels
{
	[RequireComponent(typeof(AudioSource))]
	public class BrickSound : MonoBehaviour
	{
		[SerializeField] private AudioClip brockenSound;
		[SerializeField] private AudioClip destroySound;
		
		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void OnEnable()
		{
			Brick.OnBrickDamage += PlayBrockenSound;
			Brick.OnBrickDestroy += PlayDestroySound;
		}

		private void OnDisable()
		{
			Brick.OnBrickDamage -= PlayBrockenSound;
			Brick.OnBrickDestroy -= PlayDestroySound;
		}

		private void PlayBrockenSound()
		{
			_audioSource.PlayOneShot(brockenSound);
		}

		private void PlayDestroySound()
		{
			_audioSource.PlayOneShot(destroySound);
		}
	}
}