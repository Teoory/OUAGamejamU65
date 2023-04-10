using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    [SerializeField] Button winButton;


    private void Start()
    {
        winButton.onClick.AddListener(WinButton);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
  
    }
  
    private void WinButton()
    {
        SceneManager.LoadScene(0);
    }
}
