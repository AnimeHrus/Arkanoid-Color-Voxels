using System.Collections;
using UnityEngine;

namespace ArkanoidColorVoxels
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private GameObject visual;
        [SerializeField] private Transform gameParent;
        [SerializeField] private Transform startPosition;
        [SerializeField] private float impulse = 1f;
        [SerializeField] private float directionMultiply = 1f;
        [SerializeField] private float relaunchDelay = 1f;

        private Rigidbody _rigidBody;
        private SphereCollider _collider;
        private TrailRenderer _trail;
        private bool _isActive;
        private float _lastPositionX;
        private WaitForSeconds _relaunchWait;
        
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<SphereCollider>();
            _trail = GetComponent<TrailRenderer>();
            _isActive = false;
            _relaunchWait = new WaitForSeconds(relaunchDelay);
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
            StartCoroutine(RelaunchByTime());
        }

        private IEnumerator RelaunchByTime()
        {
            _isActive = false;
            visual.SetActive(false);
            _collider.enabled = false;
            _rigidBody.isKinematic = true;
            _trail.enabled = false;
            transform.SetParent(startPosition);
            transform.localPosition = Vector3.zero;
            yield return _relaunchWait;
            visual.SetActive(true);
            yield return _relaunchWait;
            _isActive = true;
            _lastPositionX = transform.position.x;
            transform.SetParent(gameParent);
            _collider.enabled = true;
            _rigidBody.isKinematic = false;
            _trail.enabled = true;
            _rigidBody.AddForce(Vector3.down * impulse, ForceMode.Impulse);
        }
        
        private void StartMove()
        {
            if (_isActive) return;
            _isActive = true;
            _lastPositionX = transform.position.x;
            transform.SetParent(gameParent);
            _collider.enabled = true;
            _rigidBody.isKinematic = false;
            _trail.enabled = true;
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
