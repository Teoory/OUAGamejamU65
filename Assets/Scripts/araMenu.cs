using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class araMenu : MonoBehaviour
{
    [SerializeField] Button playAgainButton;
    [SerializeField] Button menuButton;

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgainButton);
        menuButton.onClick.AddListener(MenuButton);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    private void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

}

