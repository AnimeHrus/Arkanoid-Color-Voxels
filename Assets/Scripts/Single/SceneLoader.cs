using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArkanoidColorVoxels
{
    public class SceneLoader : MonoBehaviour
    {
        [Header("Scene change variables")]
        [SerializeField] private Scenes scene = Scenes.GameZone;

        public void ChangeScene()
        {
            SceneManager.LoadScene((int)scene);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private enum Scenes:int
        {
            SplashScreen,
            GameZone
        }
    }
}

