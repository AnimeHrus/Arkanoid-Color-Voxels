using UnityEngine;

public class PlayerBallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SceneController>(out SceneController scene))
        {
            scene.RestartScene();
        }

        if (collision.gameObject.TryGetComponent<BrickState>(out BrickState brick))
        {
            brick.GetDamage();
        }
    }
}
