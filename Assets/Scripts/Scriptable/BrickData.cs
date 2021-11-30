using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	[CreateAssetMenu(fileName = "BrickData", menuName = "GameData/Create/BrickData")]
	public class BrickData : ScriptableObject
	{
		public GameObject Prefab;
		public List<GameObject> Models;
		public Texture DefaultTexture;
		public Texture BrockenTexture;
		public int Score;
	}
}