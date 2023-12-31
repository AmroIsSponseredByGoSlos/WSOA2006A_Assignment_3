using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public float RayLength = 10f;
    public Material HighLight;
    public Material NormalMaterial;
    public Material TransparentMaterial;
    public GameObject Props;
    public GameObject Player;
    public int ActiveProp = 0;
    public bool IsHighlighting = false;
    public AudioSource src;
    public AudioClip Zipper;
    public GameController gameController;

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
                if (Input.GetMouseButtonDown(0) && gameController.StudySessionFinished)
                {
                    src.clip = Zipper;
                    src.Play();
                    Transform[] Children = Player.GetComponentsInChildren<Transform>(true);
                    foreach (Transform f in Children)
                    {
                        if (Hit.transform.gameObject.name == "Jug_01")
                        {
                            if (f.gameObject.name == "Main Camera" || f.gameObject.name == "Player" || f.gameObject.name == "Jug_01")
                            {
                                f.gameObject.SetActive(true);
                                ActiveProp = 1;
                                IsHighlighting = true;
                            }
                            else
                            {
                                f.gameObject.SetActive(false);
                            }
                        }
                        else if (Hit.transform.gameObject.name == "Jug_02")
                        {
                            if (f.gameObject.name == "Main Camera" || f.gameObject.name == "Player" || f.gameObject.name == "Jug_02")
                            {
                                f.gameObject.SetActive(true);
                                ActiveProp = 2;
                                IsHighlighting = true;
                            }
                            else
                            {
                                f.gameObject.SetActive(false);
                            }
                        }
                        else if (Hit.transform.gameObject.name == "Box_01")
                        {
                            if (f.gameObject.name == "Main Camera" || f.gameObject.name == "Player" || f.gameObject.name == "Box_01")
                            {
                                f.gameObject.SetActive(true);
                                ActiveProp = 3;
                                IsHighlighting = true;
                            }
                            else
                            {
                                f.gameObject.SetActive(false);
                            }
                        }
                        else if (Hit.transform.gameObject.name == "SlantedStairs_01")
                        {
                            if (f.gameObject.name == "Main Camera" || f.gameObject.name == "Player" || f.gameObject.name == "SlantedStairs_01")
                            {
                                f.gameObject.SetActive(true);
                                if (f.gameObject.name == "Player")
                                {
                                    Renderer PlayerRenderer = f.gameObject.GetComponent<Renderer>();
                                    PlayerRenderer.material = TransparentMaterial;
                                    ActiveProp = 4;
                                    IsHighlighting = true;
                                }
                            }
                            else
                            {
                                f.gameObject.SetActive(false);
                            }
                        }
                        else if (Hit.transform.gameObject.name == "Stairs_01")
                        {
                            if (f.gameObject.name == "Main Camera" || f.gameObject.name == "Player" || f.gameObject.name == "Stairs_01")
                            {
                                f.gameObject.SetActive(true);
                                if (f.gameObject.name == "Player")
                                {
                                    Renderer PlayerRenderer = f.gameObject.GetComponent<Renderer>();
                                    PlayerRenderer.material = TransparentMaterial;
                                    ActiveProp = 5;
                                    IsHighlighting = true;
                                }
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
            IsHighlighting = false;
        }
    }
}
