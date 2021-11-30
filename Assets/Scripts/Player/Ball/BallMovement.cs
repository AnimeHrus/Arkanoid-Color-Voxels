using System.Collections;
using UnityEngine;

namespace ArkanoidColorVoxels
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Transform gameParent;
        [SerializeField] private Transform startPosition;
        [SerializeField] private float impulse = 1f;
        [SerializeField] private float directionMultiply = 1f;
        [SerializeField] private float relaunchDelay = 1f;

        private Rigidbody _rigidBody;
        private bool _isActive;
        private float _lastPositionX;
        private WaitForSeconds _relaunchWait;
        
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _isActive = false;
            _relaunchWait = new WaitForSeconds(relaunchDelay);
        }

        private void Start()
        {
            _rigidBody.isKinematic = true;
        }

        private void OnEnable()
        {
            GameMusic.OnStartMusicCompleted += StartMove;
        }

        private void OnDisable()
        {
            GameMusic.OnStartMusicCompleted -= StartMove;
        }

        public void Relaunch()
        {
            _isActive = false;
            _rigidBody.isKinematic = true;
            transform.SetParent(startPosition);
            transform.localPosition = Vector3.zero;
            StartCoroutine(RelaunchByTime());
        }

        private IEnumerator RelaunchByTime()
        {
            yield return _relaunchWait;
            StartMove();
        }
        
        private void StartMove()
        {
            _lastPositionX = transform.position.x;
            if (_isActive) return;
            _isActive = true;
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
