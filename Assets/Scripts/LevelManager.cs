using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   [SerializeField] Button startGameButton;
    [SerializeField] Button quitGameButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        quitGameButton.onClick.AddListener(QuitGame);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
