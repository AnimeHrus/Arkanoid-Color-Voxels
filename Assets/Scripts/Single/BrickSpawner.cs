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
			for (int i = 0; i < gameLevel.Bricks.Count; i++)
			{
				GameObject game;
#if UNITY_EDITOR
				game = PrefabUtility.InstantiatePrefab(gameLevel.Bricks[i].Brick.Prefab, parent) as GameObject;
				if (game.TryGetComponent(out Brick brick))
				{
					brick.BrickData = gameLevel.Bricks[i].Brick;
					brick.SetData(gameLevel.Bricks[i].Brick);
				}
#else
				game = GameObject.Instantiate(gameLevel.Bricks[i].Brick.Prefab, parent);
				if (game.TryGetComponent(out Brick brick1))
				{
					BrickData brickdata = gameLevel.Bricks[i].Brick;
					brick.SetData(brickdata);
				}
#endif
				game.transform.position = gameLevel.Bricks[i].Position;
			}
		}
	}
}