using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ArkanoidColorVoxels
{
	[RequireComponent(typeof(AudioSource))]
	public class GameSFX : MonoBehaviour
	{
		[SerializeField] private AudioClip bounce;
		[SerializeField] private List<AudioClip> breakages;
		[SerializeField] private AudioClip miss;
		[SerializeField] private AudioClip relaunch;

		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void OnEnable()
		{
			BallMovement.OnBounce += PlayBounce;
			LostZone.OnMiss += PlayMiss;
			BallDamage.OnBreaked += PlayBreak;
			BallRelaunch.OnRelaunch += PlayRelaunch;
		}

		private void OnDisable()
		{
			BallMovement.OnBounce -= PlayBounce;
			LostZone.OnMiss -= PlayMiss;
			BallDamage.OnBreaked -= PlayBreak;
			BallRelaunch.OnRelaunch -= PlayRelaunch;
		}

		private void PlayBounce()
		{
			_audioSource.clip = bounce;
			_audioSource.Play();
		}
		
		private void PlayBreak()
		{
			int random = Random.Range(0, breakages.Count);
			_audioSource.clip = breakages[random];
			_audioSource.Play();
		}

		private void PlayMiss()
		{
			_audioSource.clip = miss;
			_audioSource.Play();
		}
		
		private void PlayRelaunch()
		{
			_audioSource.clip = relaunch;
			_audioSource.Play();
		}
	}
}