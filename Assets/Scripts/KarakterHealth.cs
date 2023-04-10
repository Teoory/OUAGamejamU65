using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class KarakterHealth : MonoBehaviour
{
    public GameObject deathCanvas;
    public float PlayerHealth;
    [SerializeField] private float PlayerMaxHealth = 3.0f;
    [SerializeField] private Slider healthSlider;
    bool tuzakTemas = false;
    public KeyCode reloadButton = KeyCode.Space;

    private void Start() {
        PlayerHealth = PlayerMaxHealth;
        healthSlider.maxValue = PlayerMaxHealth; 
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("tuzak"))
        {
            tuzakTemas = true;
            if(tuzakTemas)
            tuzak();
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("tuzak"))
        tuzakTemas = false;
    }

    void tuzak()
    {
        PlayerHealth -= 1.0f;
    }

    private void Update() {
        healthSlider.value = PlayerHealth;

        if ( PlayerHealth > PlayerMaxHealth) {
            PlayerHealth = PlayerMaxHealth;
        } else if (PlayerHealth <= 0f) {
            PlayerHealth = 0f;
            healthSlider.value = PlayerHealth;
            Debug.Log("Dead");
            SceneManager.LoadScene("araMenu");
            // deathCanvas.SetActive(true);
            // Time.timeScale = 0.0f;
            // if(Input.GetKey(reloadButton))
            // {
            //     Time.timeScale = 1.0f;
            //     SceneManager.LoadScene("araMenu");
            // }
        }
    }

    public void death()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("araMenu");
    }
    
}
