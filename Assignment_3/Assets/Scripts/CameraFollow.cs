using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
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
        transform.position = Vector3.Slerp(transform.position, NewPos, smoothFactor);
    }
}
