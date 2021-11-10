using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        #region UI events

        public void Resume()
        {
            _gameManager.Pause();
        }

        public void NewGame()
        {
            SceneManager.LoadScene("Main");
            Time.timeScale = 1;
        }

        public void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPaused = true;
#else
        Application.Quit();
#endif
        }

        #endregion
    }
}