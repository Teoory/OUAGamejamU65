using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    public bool win = false;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("goal"))
        {
            win = true;
        }
    }

    void Update()
    {
        if(win)
        {SceneManager.LoadScene("win");}
    }
}
