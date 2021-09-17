using UnityEngine;

public class PlayerBallMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _launchVector2D = new Vector2(2f, 4f);
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameMusic.OnStartMusicCompleted += StartBall;
    }

    private void OnDisable()
    {
        GameMusic.OnStartMusicCompleted -= StartBall;
    }

    private void StartBall()
    {
        _rigidBody.velocity = new Vector2(Random.Range(_launchVector2D.x, _launchVector2D.y), Random.Range(_launchVector2D.x, _launchVector2D.y));
    }
}
