using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GroundedChechk : MonoBehaviour
{
    public float mesafe = .10f;
    public bool Grounded = true;

    public event System.Action yerde;

    const float origin = .001f;
    Vector3 RaycastOrigin => transform.position + Vector3.up * origin;
    float RaycastDistance => mesafe + origin;

    void LateUpdate()
    {
        bool zeminde = Physics.Raycast(RaycastOrigin, Vector3.down, mesafe * 2);
        if (zeminde && !Grounded)
        {
            yerde?.Invoke();
        }
        Grounded = zeminde;
    }

    void OnDrawGizmosSelected()
    {
        Debug.DrawLine(RaycastOrigin, RaycastOrigin + Vector3.down * RaycastDistance, Grounded ? Color.white : Color.red);
    }
}
