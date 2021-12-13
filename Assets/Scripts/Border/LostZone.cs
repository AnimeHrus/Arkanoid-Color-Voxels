using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class LostZone : MonoBehaviour
	{
		public delegate void BallSfx();
		public static event BallSfx OnMiss;
		
		public delegate void BallShake(float duration, float amount);
		public static event BallShake OnMissShake;
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent(out BallRelaunch ball))
			{
				OnMiss?.Invoke();
				OnMissShake?.Invoke(0.1f, 0.02f);
				ball.Relaunch();
			}
		}
	}
}