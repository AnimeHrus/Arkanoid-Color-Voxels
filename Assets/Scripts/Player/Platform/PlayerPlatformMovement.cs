using UnityEngine;

public class PlayerPlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speedModifier = 0.01f;
    [SerializeField] private float _clampPositionX = 7f;
    private bool _allowedMove = false;

    private void OnEnable()
    {
        PlayerTapInput.OnTapedToScreen += MoveTapDeltaPosition;
        GameMusic.OnStartMusicCompleted += AllowMove;
    }

    private void OnDisable()
    {
        PlayerTapInput.OnTapedToScreen -= MoveTapDeltaPosition;
        GameMusic.OnStartMusicCompleted -= AllowMove;
    }

    private void AllowMove()
    {
        _allowedMove = true;
    }

    private void MoveTapDeltaPosition(Vector3 direction)
    {
        if (_allowedMove)
        {
            direction *= _speedModifier;
            transform.position += direction;
            ClampLocalPosition();
        }
    }

    private void ClampLocalPosition()
    {
        transform.localPosition = new Vector3(
        Mathf.Clamp(transform.localPosition.x, -_clampPositionX, _clampPositionX),
        transform.localPosition.y,
        transform.localPosition.z);
    }
}
