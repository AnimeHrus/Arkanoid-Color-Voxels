using UnityEngine;

namespace ArkanoidColorVoxels
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Transform gameParent;
        [SerializeField] private float impulse = 1f;
        [SerializeField] private float directionMultiply = 1f;

        public Transform GameParent
        {
            get
            {
                return gameParent;
            }
        }
        
        public float Impulse
        {
            get
            {
                return impulse;
            }
        }
        
        public Rigidbody RigidBody
        {
            get
            {
                return _rigidBody;
            }
            set
            {
                _rigidBody.isKinematic = value;
                _rigidBody.velocity = value.velocity;
            }
        }
        
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }
        
        public float LastPositionX
        {
            get
            {
                return _lastPositionX;
            }
            set
            {
                _lastPositionX = value;
            }
        }
        
        private Rigidbody _rigidBody;
        private bool _isActive;
        private float _lastPositionX;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _isActive = false;
        }

        private void OnEnable()
        {
            GameMusic.OnStartMusicCompleted += StartMove;
        }

        private void OnDisable()
        {
            GameMusic.OnStartMusicCompleted -= StartMove;
        }

        private void StartMove()
        {
            if (_isActive) return;
            _isActive = true;
            _lastPositionX = transform.position.x;
            transform.SetParent(gameParent);
            _rigidBody.isKinematic = false;
            _rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var ballPositionX = transform.position.x;
            
            if (other.gameObject.TryGetComponent(out PlatformMovement platform))
            {
                if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1)
                {
                    if (!_isActive) return;
                    var collisionPointX = other.contacts[0].point.x;
                    _rigidBody.velocity = Vector3.zero;
                    var platformCenterPosition = platform.gameObject.GetComponent<Transform>().position.x;
                    var difference = platformCenterPosition - collisionPointX;
                    var direction = collisionPointX < platformCenterPosition ? -directionMultiply : directionMultiply;
                    _rigidBody.AddForce(new Vector3(direction * Mathf.Abs(difference * (impulse * 0.5f)), impulse, 0f), ForceMode.Impulse);
                }
            }

            _lastPositionX = ballPositionX;
        }
    }
}
