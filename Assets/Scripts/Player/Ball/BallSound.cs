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
		}

		private void OnCollisionEnter()
		{
			_audioSource.PlayOneShot(bounceSound);
		}
	}
}