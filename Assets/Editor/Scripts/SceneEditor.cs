using UnityEditor;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class SceneEditor : EditorWindow
	{
		private readonly EditorGrid _grid = new EditorGrid();
		private LevelEditor _levelEditor;
		private Transform _parent;
		
		public void SetLevelEditor(LevelEditor levelEditor, Transform parent)
		{
			_parent = parent;
			_levelEditor = levelEditor;
		}

		public void OnSceneGUI(SceneView sceneView)
		{
			Event current = Event.current;
			if (current.type == EventType.MouseDown)
			{
				Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x,
					sceneView.camera.pixelHeight - current.mousePosition.y,
					sceneView.camera.nearClipPlane));
				Vector3 position = _grid.CheckPosition(point);
				if (position != Vector3.zero)
				{
					if (IsEmpty(position))
					{
						GameObject game =
							PrefabUtility.InstantiatePrefab(_levelEditor.GetBrick().Prefab, _parent) as GameObject;
						game.transform.position = point;

						if (game.TryGetComponent(out Brick brick))
						{
							brick.BrickData = _levelEditor.GetBrick();
							brick.SetData(_levelEditor.GetBrick());
						}
					}
				}
			}

			if (current.type == EventType.Layout)
			{
				HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
			}
		}

		private bool IsEmpty(Vector3 position)
		{
			Collider[] collider = Physics.OverlapSphere(position, 0.01f);
			return collider == null;
		}
	}
}