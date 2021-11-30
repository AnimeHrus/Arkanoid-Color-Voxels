using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	[CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Create/Data")]
	public class EditorData : ScriptableObject
	{
		public List<EditorBrickData> BrickDatas = new List<EditorBrickData>();
	}
	
	[System.Serializable]
	public class EditorBrickData
	{
		public Texture2D Texture2D;
		public BrickData BrickData;
	}
}