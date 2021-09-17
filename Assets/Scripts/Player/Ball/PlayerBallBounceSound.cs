using UnityEngine;

public class PlayerBallBounceSound : MonoBehaviour
{
    [SerializeField] private AudioSource _ballBounce;

    private void OnCollisionEnter(Collision collision)
    {
        _ballBounce.Play();
    }
}
