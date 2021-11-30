using ArkanoidColorVoxels.Input;
using UnityEngine;

namespace ArkanoidColorVoxels
{
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private float speedModifier = 0.004f;
        
        private const float CLAMP_POSITION_X = 1.24f;
        private bool _allowedMove = true;

        private void OnEnable()
        {
            TapInput.OnTapedToScreen += MoveTapDeltaPosition;
            GameMusic.OnStartMusicCompleted += AllowMove;
        }

        private void OnDisable()
        {
            TapInput.OnTapedToScreen -= MoveTapDeltaPosition;
            GameMusic.OnStartMusicCompleted -= AllowMove;
        }

        private void AllowMove()
        {
            _allowedMove = true;
        }

        private void MoveTapDeltaPosition(Vector3 direction)
        {
            if (!_allowedMove) return;
            direction *= speedModifier;
            transform.position += direction;
            ClampLocalPosition();
        }

        private void ClampLocalPosition()
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(
                Mathf.Clamp(localPosition.x, -CLAMP_POSITION_X, CLAMP_POSITION_X),
                localPosition.y,
                localPosition.z);
            transform.localPosition = localPosition;
        }
    }
}
