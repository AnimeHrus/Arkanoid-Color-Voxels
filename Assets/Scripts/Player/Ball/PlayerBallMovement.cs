using UnityEngine;

public class PlayerBallMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _vector2D = new Vector2(2f, 4f);
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidBody.velocity = new Vector2(Random.Range(_vector2D.x, _vector2D.y), Random.Range(_vector2D.x, _vector2D.y));
    }
}
