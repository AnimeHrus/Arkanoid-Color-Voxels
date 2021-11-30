using UnityEditor;
using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class LevelEditor : EditorWindow
	{
		private Transform _brickParent;
		private EditorData _data;
		private int _index;
		private bool _isEnabledEdit;
		private GameLevel _gameLevel;
		private SceneEditor _sceneEditor;
		
		[MenuItem("Window/Level Editor")]
		public static void Init()
		{
			LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
			levelEditor.Show();
		}

		private void OnGUI()
		{
			EditorGUILayout.Space(10);
			_brickParent = (Transform) EditorGUILayout.ObjectField(_brickParent, typeof(Transform), true);
			EditorGUILayout.Space(30);

			if (_data == null)
			{
				if (GUILayout.Button("Load Data"))
				{
					_data = (EditorData) AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset",
						typeof(EditorData));
					_sceneEditor = CreateInstance<SceneEditor>();
					_sceneEditor.SetLevelEditor(this, _brickParent);
				}
			}
			else
			{
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Brick prefab", EditorStyles.boldLabel);
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				
				EditorGUILayout.Space(5);
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
				{
					_index--;
					if (_index < 0)
					{
						_index = _data.BrickDatas.Count - 1;
					}
				}
				
				GUILayout.Label(_data.BrickDatas[_index].Texture2D);
				
				if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
				{
					_index++;
					if (_index > _data.BrickDatas.Count - 1)
					{
						_index = 0;
					}
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.Space(30);

				GUI.color = _isEnabledEdit ? Color.green : Color.white;
				if (GUILayout.Button("Create bricks"))
				{
					_isEnabledEdit = !_isEnabledEdit;

					if (_isEnabledEdit)
					{
						SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
					}
					else
					{
						SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
					}
				}
				GUI.color = Color.white;
				GUILayout.Space(30);

				_gameLevel = (GameLevel) EditorGUILayout.ObjectField(_gameLevel, typeof(GameLevel), false);
				GUILayout.Space(30);
				
				GUILayout.BeginHorizontal();
				if (GUILayout.Button("Save Level"))
				{
					SaveLevel saveLevel = new SaveLevel();
					_gameLevel.Bricks = saveLevel.GetBricks();
					EditorUtility.SetDirty(_gameLevel);
					Debug.Log("Level Saved");
				}

				if (GUILayout.Button("Load Level"))
				{
					GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Brick");
					foreach (var item in allBricks)
					{
						DestroyImmediate(item.gameObject);
					}

					BrickSpawner brickSpawner = new BrickSpawner();
					brickSpawner.Generate(_gameLevel, _brickParent);
					Debug.Log("Level Loaded");
				}
				GUILayout.EndHorizontal();
			}
		}

		public BrickData GetBrick()
		{
			return _data.BrickDatas[_index].BrickData;
		}
	}
}