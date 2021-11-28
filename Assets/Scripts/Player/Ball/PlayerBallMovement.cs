using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBallMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartBall();
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
        _rigidBody.velocity = Vector3.up * 10;
    }
}
