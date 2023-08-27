using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    public Material HighLight;
    public float RayLength = 10f;
    public GameObject Props;
    public Material NormalMaterial;
    public ShapeShift shapeShift;
    // Start is called before the first frame update
    void Start()
    {
        shapeShift = GameObject.Find("Player").GetComponent<ShapeShift>();
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
                Debug.Log(Hit.transform.gameObject.name);
                Renderer ObjectRenderer = Hit.transform.gameObject.GetComponent<Renderer>();
                ObjectRenderer.material = HighLight;
                if (Input.GetKey(KeyCode.Space))
                {
                    if (Hit.transform.parent.name == "Player" && shapeShift.ActiveProp == 1)
                    {
                        Debug.Log("Working");
                    }
                }
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
