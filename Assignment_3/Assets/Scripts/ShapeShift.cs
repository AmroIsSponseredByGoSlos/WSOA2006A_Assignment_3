using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public float RayLength = 10f;
    public Material HighLight;
    public Material NormalMaterial;
    public GameObject Props;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
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
                if (Input.GetMouseButtonDown(0))
                {
                    Transform[] Children = Player.GetComponentsInChildren<Transform>(true);
                    foreach (Transform f in Children)
                    {
                        if (Hit.transform.gameObject.name == "Jug_01")
                        {
                            if (f.gameObject.name == "Main Camera" || f.gameObject.name == "Player" || f.gameObject.name == "Jug_01")
                            {
                                f.gameObject.SetActive(true);
                                Debug.Log(f.gameObject.name);
                            }
                            else
                            {
                                f.gameObject.SetActive(false);
                            }
                        }
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
    public void PropShapeShift()
    {
       
    }
}
