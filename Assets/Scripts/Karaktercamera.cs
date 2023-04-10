using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Karaktercamera : MonoBehaviour
{
    [SerializeField]Transform player;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector3 velocity;
    Vector3 frameVelocity;

    
    void Reset()
    {
        player = GetComponentInParent<KarakterKontrol>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 mouseDelta = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector3 rawFrameVelocity = Vector3.Scale(mouseDelta, Vector3.one * sensitivity);
        frameVelocity = Vector3.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        player.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }



    
    // void OnDrawGizmosSelected()
    // {
    //     // baktığı yeri gösteren gizmos
    //     Vector3 forward = transform.TransformDirection(Vector3.forward) * 5;
    //     Debug.DrawRay(transform.position, forward, Color.red);
    // }
}
