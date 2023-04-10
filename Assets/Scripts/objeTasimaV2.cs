using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeTasimaV2 : MonoBehaviour
{
    [SerializeField] Transform objePozisyonu;
    private GameObject secilenObje;
    private Rigidbody secilenObjeRB;

    public bool _elimizdemi = false;
    [SerializeField] private float _neKadarUzaktanTutulabilir = 5.0f;

    
    [Header("keyCodes")]
    public KeyCode HoldKey = KeyCode.Q;

    private void Update() {
        if(Input.GetKeyDown(HoldKey))
        {
            if (secilenObje == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _neKadarUzaktanTutulabilir) && hit.transform.tag == "engel" || hit.transform.tag == "kitap")
                { 
                    PickupObject(hit.transform.gameObject);
                    _elimizdemi = true;
                }
            }else
            {
                DropObject();
                _elimizdemi = false;
            }
        }
        if(secilenObje != null)
        {
            MoveObject();            
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(secilenObje.transform.position, objePozisyonu.position) > 0.1f)
        {
            Vector3 moveDirection = (objePozisyonu.position - secilenObje.transform.position);
            secilenObjeRB.AddForce(moveDirection * 150f);
        }
    }

    void PickupObject(GameObject elindekiObje)
    {
        if(elindekiObje.CompareTag("engel") || elindekiObje.CompareTag("kitap")){
            if(elindekiObje.GetComponent<Rigidbody>())
            {
                elindekiObje.GetComponent<Collider>().isTrigger = true;
                secilenObjeRB = elindekiObje.GetComponent<Rigidbody>();
                secilenObjeRB.useGravity = false;
                secilenObjeRB.drag = 10;
                secilenObjeRB.mass = 1;
                secilenObjeRB.constraints = RigidbodyConstraints.FreezeRotation;
    
                secilenObjeRB.transform.parent = objePozisyonu;
                secilenObje = elindekiObje;
            }
        }
    }
    void DropObject()
    {
        secilenObje.GetComponent<Collider>().isTrigger = false;
        secilenObjeRB.useGravity = true;
        secilenObjeRB.drag = 1;
        secilenObjeRB.mass = 50;
        secilenObjeRB.constraints = RigidbodyConstraints.None;

        secilenObje.transform.parent = null;
        secilenObje = null;
    }

    
    void OnDrawGizmosSelected()
    {
        // baktığı yeri gösteren gizmos
        Vector3 forward = transform.TransformDirection(Vector3.forward) * _neKadarUzaktanTutulabilir;
        Debug.DrawRay(transform.position, forward, Color.red);
    }

}
