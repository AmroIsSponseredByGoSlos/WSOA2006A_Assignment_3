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
    public bool SeekerHighlighting = false;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
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
                SeekerHighlighting = true;
                Renderer ObjectRenderer = Hit.transform.gameObject.GetComponent<Renderer>();
                ObjectRenderer.material = HighLight;
            }
            if (Hit.transform.gameObject.name == "Player")
            {
                for (int i = 0; i < Player.transform.childCount; i++)
                {
                    SeekerHighlighting = true;
                    Transform child = Player.transform.GetChild(i);
                    if (child.gameObject.name != "Main Camera" && child.gameObject.name != "Player" && child.gameObject.name != "HiderCanvas")
                    {
                        Renderer ChildRenderer = child.GetComponent<Renderer>();
                        ChildRenderer.material = HighLight;
                        if (Input.GetKey(KeyCode.Space))
                        {
                            if (shapeShift.ActiveProp == 1)
                            {
                                Debug.Log("The player is hiding as Jug_01");
                            }
                            if (shapeShift.ActiveProp == 2)
                            {
                                Debug.Log("The player is hiding as Jug_02");
                            }
                            if (shapeShift.ActiveProp == 3)
                            {
                                Debug.Log("The player is hiding as Box_01");
                            }
                            if (shapeShift.ActiveProp == 4)
                            {
                                Debug.Log("The player is hiding as SlantedStairs_01");
                            }
                            if (shapeShift.ActiveProp == 5)
                            {
                                Debug.Log("The player is hiding as Stairs_01");
                            }
                        }
                    }
                }
            }
        }
        else
        {
            SeekerHighlighting = false;
            if (shapeShift.IsHighlighting == false && SeekerHighlighting == false)
            {
                for (int i = 0; i < Props.transform.childCount; i++)
                {
                    Transform child = Props.transform.GetChild(i);
                    Renderer ChildRenderer = child.GetComponent<Renderer>();
                    ChildRenderer.material = NormalMaterial;
                }
                for (int i = 0; i < Player.transform.childCount; i++)
                {
                    Transform child = Player.transform.GetChild(i);
                    if (child.gameObject.name != "Main Camera" && child.gameObject.name != "Player" && child.gameObject.name != "HiderCanvas")
                    {
                        Renderer ChildRenderer = child.GetComponent<Renderer>();
                        ChildRenderer.material = NormalMaterial;
                    }                       
                }
            }
        }
    }
}
