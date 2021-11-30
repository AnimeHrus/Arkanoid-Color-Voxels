using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class LostZone : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent(out BallMovement ball))
			{
				Destroy(ball.gameObject);
			}
		}
	}
}