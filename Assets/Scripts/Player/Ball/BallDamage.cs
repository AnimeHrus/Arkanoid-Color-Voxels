using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class BallDamage : MonoBehaviour
	{
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out Brick brick))
			{
				brick.ApplyDamage();
			}
		}
	}
}