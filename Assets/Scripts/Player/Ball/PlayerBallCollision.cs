using UnityEngine;

public class PlayerBallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SceneLoader>(out SceneLoader scene))
        {
            scene.RestartScene();
        }

        if (collision.gameObject.TryGetComponent<BrickState>(out BrickState brick))
        {
            brick.GetDamage();
        }
    }
}
