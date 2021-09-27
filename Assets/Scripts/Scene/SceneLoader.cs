using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene change variables")]
    [SerializeField] private Scenes _scene = Scenes.GameZone_scene;

    public void ChangeScene()
    {
        SceneManager.LoadScene((int)_scene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private enum Scenes:int
    {
        SplashScreen_scene,
        GameZone_scene
    }
}
