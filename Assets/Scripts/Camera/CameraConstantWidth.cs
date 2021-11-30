using UnityEngine;

namespace ArkanoidColorVoxels.Tools
{
    [RequireComponent(typeof(Camera))]
    public class CameraConstantWidth : MonoBehaviour
    {
        [SerializeField] private Vector2 defaultResolution = new Vector2(720, 1280);
        [SerializeField, Range(0f, 1f)] private float widthOrHeight;
        private Camera _camera;
        private float _initialSize;
        private float _targetAspect;
        private float _initialFov;
        private float _horizontalFov = 120f;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _initialSize = _camera.orthographicSize;
            _targetAspect = defaultResolution.x / defaultResolution.y;
            _initialFov = _camera.fieldOfView;
            _horizontalFov = CalcVerticalFov(_initialFov, 1 / _targetAspect);
        }

        private void Start()
        {
            if (_camera.orthographic)
            {
                var constantWidthSize = _initialSize * (_targetAspect / _camera.aspect);
                _camera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, widthOrHeight);
            }
            else
            {
                var constantWidthFov = CalcVerticalFov(_horizontalFov, _camera.aspect);
                _camera.fieldOfView = Mathf.Lerp(constantWidthFov, _initialFov, widthOrHeight);
            }
        }

        private static float CalcVerticalFov(float hFovInDeg, float aspectRatio)
        {
            var hFovInRads = hFovInDeg * Mathf.Deg2Rad;
            var vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
            return vFovInRads * Mathf.Rad2Deg;
        }
    }
}