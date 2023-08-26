using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset = new Vector3(13.3697f, 6.4f, 9.11f);
    public float smoothFactor = 0.35f;
    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 NewPos = Target.transform.position + Offset;      
        Vector3 lookDirection = Target.forward;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothFactor);
        transform.position = Vector3.Slerp(transform.position, NewPos, smoothFactor);   
    }
}
