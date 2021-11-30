using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class Brick : MonoBehaviour
	{
		private static int _count;
		[SerializeField] private List<GameObject> models;
		[SerializeField] private int score;
		[SerializeField] private GameObject currentModel;
		[SerializeField] private int durability;
		[SerializeField] private Renderer modelRenderer;
		[SerializeField] private Texture brockenTexture;

#if UNITY_EDITOR
		public BrickData BrickData;
#endif
		public delegate void BrickDamage();
		public static event BrickDamage OnBrickDamage;
		public static event BrickDamage OnBrickDestroy;
		
		public void SetData(BrickData brickData)
		{
			models = brickData.Models;
			durability = models.Count;
			score = brickData.Score;
			currentModel = Instantiate(models[durability - 1], transform);
			modelRenderer = currentModel.GetComponent<Renderer>();
			modelRenderer.material.mainTexture = brickData.DefaultTexture;
			brockenTexture = brickData.BrockenTexture;
		}

		public void ApplyDamage()
		{
			durability--;
			if (durability < 1)
			{
				OnBrickDestroy?.Invoke();
				Destroy(gameObject);
			}
			else
			{
				OnBrickDamage?.Invoke();
				Destroy(currentModel);
				currentModel = Instantiate(models[durability - 1], transform);
				modelRenderer = currentModel.GetComponent<Renderer>();
				modelRenderer.material.mainTexture = brockenTexture;
			}
		}
		
		private void OnEnable()
		{
			_count++;
		}

		private void OnDisable()
		{
			_count--;
			if (_count < 1)
			{
				Debug.Log("Bricks is gone");
			}
		}
	}
}