using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class SaveLevel : MonoBehaviour
	{
		public List<BrickObject> GetBricks()
		{
			List<BrickObject> objects = new List<BrickObject>();
			GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Brick");

			foreach (var item in allBricks)
			{
				BrickObject brickObject = new BrickObject();
				brickObject.Position = item.gameObject.transform.position;

				if (item.TryGetComponent(out Brick brick))
				{
					brickObject.Brick = brick.BrickData;
				}
				
				objects.Add(brickObject);
			}

			return objects;
		}
	}
}