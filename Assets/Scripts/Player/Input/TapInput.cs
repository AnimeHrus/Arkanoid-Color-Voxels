using UnityEngine;

namespace Player.Input
{
    public class TapInput : MonoBehaviour
    {
        public delegate void TapControl(Vector3 tapPosition);
        public static event TapControl OnTapedToScreen;
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_camera != null && UnityEngine.Input.touchCount > 0)
            {
                GetDeltaTouch();
            }
        }

        private static void GetDeltaTouch()
        {
            var touch = UnityEngine.Input.GetTouch(0);
            if (touch.phase != TouchPhase.Moved) return;
            var direction = new Vector3(touch.deltaPosition.x, 0, 0);
            OnTapedToScreen?.Invoke(direction);
        }
    }
}
