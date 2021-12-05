using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class BallDamage : MonoBehaviour
	{
		public delegate void BrickSfx();
		public static event BrickSfx OnBreaked;
		
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out Brick brick))
			{
				OnBreaked?.Invoke();
				brick.ApplyDamage();
			}
		}
	}
}