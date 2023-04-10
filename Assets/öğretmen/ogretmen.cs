using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ogretmen : MonoBehaviour
{
    Animator Ogretmenanim;
    /*[SerializeField] */ public Transform hedef;
    NavMeshAgent Agent;
    public float mesafe;


    void Start()
    {

        Ogretmenanim = GetComponent<Animator>();

        Agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        Ogretmenanim.SetFloat("hýz", Agent.velocity.magnitude);

        mesafe = Vector3.Distance(transform.position, hedef.position);



        if (mesafe <= 10)
        {
            Agent.enabled = true;
            Agent.destination = hedef.position;
        }

        else
        {
            Agent.enabled = false;
        }
    }
}
