using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public float RayLength = 10f;
    public Material HighLight;
    public Material NormalMaterial;
    public GameObject Props;
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
            if (Hit.transform.gameObject.CompareTag("Selectable"))
            {
                Renderer ObjectRenderer = Hit.transform.gameObject.GetComponent<Renderer>();
                ObjectRenderer.material = HighLight;
            }
        }
        else
        {
            for (int i = 0; i < Props.transform.childCount; i++)
            {
                Transform child = Props.transform.GetChild(i);
                Renderer ChildRenderer = child.GetComponent<Renderer>();
                ChildRenderer.material = NormalMaterial;
            }
        }
    }
}
