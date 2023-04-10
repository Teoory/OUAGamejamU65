using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class objeTasima : MonoBehaviour
{

   // [SerializeField] private GameObject text;

    //private GameObject curentObje;
    private bool _elimizdeMi = false;

    private GameObject secilenObje;


    [SerializeField] private Transform objePozisyonu;
    [SerializeField] private Rigidbody objeRB;
    [SerializeField] private float objeUzaklik = 500f;

    
    [Header("keyCodes")]
    public KeyCode HoldKey = KeyCode.T;
    public KeyCode DropKey = KeyCode.Q;


    private void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            Ray ray = 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500f, (1 << 3)))
            {
                curentObje.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);


                if (hit.transform.CompareTag("cube") && !_elimizdeMi)
                {
                    secilenObje = hit.transform.gameObject;
                    if (secilenObje.GetComponent<ObjeFizigi>() == null)
                    {
                        secilenObje.AddComponent<ObjeFizigi>();
                    }
                    secilenObje.transform.SetParent(curentObje.transform, true);
                    secilenObje.transform.localPosition = Vector3.zero;
                    _elimizdeMi = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            secilenObje.transform.parent = null;
            Destroy(secilenObje.GetComponent<ObjeFizigi>());
            _elimizdeMi = false;
        }*/





        // Vector3 mousePos = Input.mousePosition;
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;

        // if (Physics.Raycast(ray, out hit, objeUzaklik) && hit.transform.gameObject.CompareTag("engel"))
        // {
        //     if (Vector3.Distance(transform.position, hit.transform.position) > 0.1f)
        //     {
        //         if (Input.GetKey(KeyCode.T))
        //         {
        //             Vector3 hareket = (objePozisyonu.position - objePozisyonu.transform.position);
        //             objeRB.AddForce(hareket * 5f);
        //             secilenObje = hit.transform.gameObject;
        //             secilenObje.transform.position = objePozisyonu.position;
        //             secilenObje.transform.rotation = Quaternion.identity;
        //             secilenObje.transform.SetParent(transform, true);
        //             secilenObje.GetComponent<Rigidbody>().useGravity = false;
        //             secilenObje.GetComponent<Collider>().isTrigger = true;
        //         }
        //     }

        // }

        // if (Input.GetKey(KeyCode.Q))
        // {
        //     secilenObje.transform.parent = null;
        //     secilenObje.GetComponent<Rigidbody>().useGravity = true;
        //     secilenObje.GetComponent<Collider>().isTrigger = false;
        // }






        

        if(Input.GetKeyDown(HoldKey))
        {
            if(secilenObje == null)
            {
                RaycastHit hits;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hits, objeUzaklik) && hits.transform.gameObject.CompareTag("engel"))
                {
                    objeyiKaldir(hits.transform.gameObject);
                    _elimizdeMi = true;
                }
            }else {
                objeyiBirak();
                _elimizdeMi = false;
            }
        }
        if(secilenObje != null)
        {
            objeHareket();
        }

    }


    void objeyiKaldir(GameObject objeyiTut)
    {
        if(objeyiTut.CompareTag("engel"))
        {if(objeyiTut.GetComponent<Rigidbody>())
            {
                objeyiTut.GetComponent<Collider>().isTrigger = true;
                objeRB = objeyiTut.GetComponent<Rigidbody>();
                objeRB.useGravity = false;
                objeRB.drag = 10;
                objeRB.constraints = RigidbodyConstraints.FreezeRotation;
                objeRB.transform.parent = objePozisyonu;
                secilenObje = objeyiTut;
            }
        }
    }

    void objeHareket()
    {
        if(Vector3.Distance(secilenObje.transform.position, objePozisyonu.position) > 0.1f)
        {
            Vector3 hareket = (objePozisyonu.position - objePozisyonu.transform.position);
            objeRB.AddForce(hareket * 5f);
        }
    }

    void objeyiBirak()
    {
        secilenObje.GetComponent<Collider>().isTrigger = false;
        objeRB.useGravity = true;
        objeRB.drag = 1;
        objeRB.constraints = RigidbodyConstraints.None;
        secilenObje.transform.parent = null;
        secilenObje = null;
    }


}