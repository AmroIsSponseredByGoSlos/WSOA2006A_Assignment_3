using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public float RayLength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.white);
            Debug.Log(Hit.transform.gameObject.name);
            if (Hit.transform.gameObject.CompareTag("Selectable"))
            {
                Debug.Log("Can change into this");
            }
        }
    }
}
