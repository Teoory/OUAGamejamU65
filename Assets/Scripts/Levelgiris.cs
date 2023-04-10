using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelgiris : MonoBehaviour
{
    [SerializeField] private GameObject Abouts;

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PLAY()
        { 
            SceneManager.LoadScene ("SampleScene");
        }
    public void About()
    {
        Abouts.SetActive(true);
    }
    public void Back()
    {
        Abouts.SetActive(false);
    }
    public void QUIT()
        { 
            Application.Quit();
            Debug.Log("CIKIS YAPTI!");
        }   
}
