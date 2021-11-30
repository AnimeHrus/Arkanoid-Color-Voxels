using UnityEngine;

namespace ArkanoidColorVoxels
{
	public class EditorGrid
	{
		private const float _leftPosition = -1.1f;
		private const float _upPosition = 4.3f;
		private const int _columnCount = 5;
		private const int _lineCount = 5;
		private const float _offsetDown = 0.3f;
		private const float _offsetRight = 0.22f;

		public Vector3 CheckPosition(Vector3 position)
		{
			float tempX = 0;
			float tempY = 0;
			float x = _leftPosition - _offsetRight * 0.5f;
			float y = _upPosition + _offsetDown * 0.5f;

			if (position.x > x && position.x < (x + _offsetRight * _columnCount) &&
			    position.y < y && position.y > (y - _offsetDown * _lineCount))
			{
				for (int i = 0; i < _columnCount; i++)
				{
					if (position.x > x && position.x < (x + _offsetRight))
					{
						tempX = x + _offsetRight * 0.5f;
						break;
					}
					else
					{
						x += _offsetRight;
					}
				}
				
				for (int i = 0; i < _lineCount; i++)
				{
					if (position.y < y && position.y > (y - _offsetDown))
					{
						tempY = y - _offsetDown * 0.5f;
						break;
					}
					else
					{
						y -= _offsetDown;
					}
				}
			}
			else
			{
				Debug.Log("Out of play zone");
			}
			
			return new Vector3();
		}
	}
}