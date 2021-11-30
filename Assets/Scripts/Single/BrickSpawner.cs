#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class BrickSpawner
	{
		public void Generate(GameLevel gameLevel, Transform parent)
		{
#if UNITY_EDITOR
			for (int i = 0; i < gameLevel.Bricks.Count; i++)
			{
				var game = PrefabUtility.InstantiatePrefab(gameLevel.Bricks[i].Brick.Prefab, parent) as GameObject;
				if (game is { } && game.TryGetComponent(out Brick brick))
				{
					brick.BrickData = gameLevel.Bricks[i].Brick;
					brick.SetData(gameLevel.Bricks[i].Brick);
				}
				if (game is { }) game.transform.position = gameLevel.Bricks[i].Position;
			}
#endif
		}
	}
}