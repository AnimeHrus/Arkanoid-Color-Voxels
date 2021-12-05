using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class LostZone : MonoBehaviour
	{
		public delegate void BallSfx();
		public static event BallSfx OnMiss;
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent(out BallRelaunch ball))
			{
				OnMiss?.Invoke();
				ball.Relaunch();
			}
		}
	}
}