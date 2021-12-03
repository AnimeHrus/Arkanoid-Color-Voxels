using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class LostZone : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent(out BallRelaunch ball))
			{
				ball.Relaunch();
			}
		}
	}
}