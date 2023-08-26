using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 CameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraPos = new Vector3(Target.transform.position.x, Target.transform.position.y + 5.91f, Target.transform.position.z - 4.71f);
        transform.position = Vector3.MoveTowards(transform.position, CameraPos, 6.3f);
        transform.forward = Target.transform.forward; 
    }
}
