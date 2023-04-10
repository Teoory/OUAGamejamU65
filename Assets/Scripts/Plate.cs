using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] public bool usePlate = false;
    public GameObject usePlate1;
    [SerializeField] private int kitaplar = 0;
    public GameObject kafes;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "kitap")
        {
            kitaplar ++;
            plateActive();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "kitap")
        {
            kitaplar --;
            plateDeactive();
        }
    }

    void Update()
    {
        if(kitaplar == 2)
        {plateActive();}
        else{plateDeactive();}

        if(usePlate)
        {kafes.SetActive(false);}
    }

    void plateActive() {
        if (gameObject.tag == "Plate")
        {
            usePlate = true;
            var plateRenderer = usePlate1.GetComponent<Renderer>();
            Color blue = new Color(0.4f, 0.9f, 0.7f, 1.0f);
            plateRenderer.material.SetColor("_Color", blue);
            usePlate1.transform.position = new Vector3(transform.position.x, 1.02f, transform.position.z);
        }
    }
    void plateDeactive() {
            usePlate = false;
            var plateRenderer = usePlate1.GetComponent<Renderer>();
            Color red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            plateRenderer.material.SetColor("_Color", red);
            usePlate1.transform.position = new Vector3(transform.position.x, 1.05f, transform.position.z);
    }


}
