using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    private Text _versionText;

    #region Lifecycle

    private void Awake() {
        _versionText.text = "ver:" + Application.version;
    }

    #endregion

    #region UI events

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
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
