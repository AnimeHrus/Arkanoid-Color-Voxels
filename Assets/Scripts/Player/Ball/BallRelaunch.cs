using System.Collections;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	[RequireComponent(typeof(BallMovement), typeof(TrailRenderer))]
	public class BallRelaunch : MonoBehaviour
	{
		[SerializeField] private GameObject visual;
		[SerializeField] private Transform relaunchParent;
		[SerializeField] private float relaunchDelay = 1f;

		private WaitForSeconds _relaunchWait;
		private BallMovement _ballMovement;
		private TrailRenderer _trail;

		public delegate void BallSfx();
		public static event BallSfx OnRelaunch;
		
		private void Awake()
		{
			_relaunchWait = new WaitForSeconds(relaunchDelay);
			_ballMovement = GetComponent<BallMovement>();
			_trail = GetComponent<TrailRenderer>();
		}

		public void Relaunch()
		{
			StartCoroutine(RelaunchByTime());
		}

		private IEnumerator RelaunchByTime()
		{
			Respawn();
			yield return _relaunchWait;
			visual.SetActive(true);
			_trail.enabled = true;
			OnRelaunch?.Invoke();
			yield return _relaunchWait;
			PrepareToLaunch();
			_ballMovement.RigidBody.AddForce(Vector3.down * _ballMovement.Impulse, ForceMode.Impulse);
		}

		private void Respawn()
		{
			_ballMovement.IsActive = false;
			visual.SetActive(false);
			_ballMovement.RigidBody.isKinematic = true;
			_ballMovement.RigidBody.velocity = Vector3.zero;
			Transform transform1;
			(transform1 = transform).SetParent(relaunchParent);
			transform1.localPosition = Vector3.zero;
			_trail.enabled = false;
		}

		private void PrepareToLaunch()
		{
			_ballMovement.IsActive = true;
			_ballMovement.LastPositionX = transform.position.x;
			_ballMovement.RigidBody.isKinematic = false;
			transform.SetParent(_ballMovement.GameParent);
		}
	}
}