using UnityEngine;

public class PlayerTapInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public delegate void TapControl(Vector3 tapPosition);
    public static event TapControl OnTapedToScreen;

    private void Update()
    {
        if (_camera != null && Input.touchCount > 0)
        {
            GetTouchPosition();
        }
    }

    private void GetTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 direction = new Vector3(touch.deltaPosition.x, 0, 0);
            OnTapedToScreen?.Invoke(direction);
        }
    }
}
