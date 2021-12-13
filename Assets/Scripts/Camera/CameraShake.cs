using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ArkanoidColorVoxels
{
	public class CameraShake : MonoBehaviour
	{
		private Coroutine _shakeRoutine;

		private void OnEnable()
		{
			Brick.OnBrickShake += Shake;
			LostZone.OnMissShake += Shake;
		}

		private void OnDisable()
		{
			Brick.OnBrickShake -= Shake;
			LostZone.OnMissShake += Shake;
		}

		private void Shake(float duration, float amount)
		{
			if (_shakeRoutine != null) StopCoroutine(_shakeRoutine);
			_shakeRoutine = StartCoroutine(ShakeRoutine(duration, amount));
		}

		private IEnumerator ShakeRoutine(float duration, float amount)
		{
			while (duration > 0)
			{
				transform.localPosition = Vector3.zero + (Vector3)Random.insideUnitCircle * amount;
				duration -= Time.deltaTime;
				yield return null;
			}

			transform.localPosition = Vector3.zero;
			_shakeRoutine = null;
		}
	}
}