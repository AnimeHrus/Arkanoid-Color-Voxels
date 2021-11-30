using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	[CreateAssetMenu(fileName = "Level", menuName = "GameData/Create/GameLevel")]
	public class GameLevel : ScriptableObject
	{
		public List<BrickObject> Bricks = new List<BrickObject>();
	}

	[System.Serializable]
	public class BrickObject
	{
		public Vector3 Position;
		public BrickData Brick;
	}
}