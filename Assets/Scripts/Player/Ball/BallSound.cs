using UnityEngine;

namespace ArkanoidColorVoxels
{
	[RequireComponent(typeof(AudioSource))]
	public class BallSound : MonoBehaviour
	{
		[SerializeField] private AudioClip bounceSound;
		
		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			_audioSource.clip = bounceSound;
		}

		private void OnCollisionEnter()
		{
			_audioSource.Play();
		}
	}
}