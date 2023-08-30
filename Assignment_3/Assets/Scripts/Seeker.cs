using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seeker : MonoBehaviour
{
    public Material HighLight;
    public float RayLength = 10f;
    public GameObject Props;
    public Material NormalMaterial;
    public ShapeShift shapeShift;
    public bool SeekerHighlighting = false;
    public GameObject Player;
    public int Searches = 3;
    public bool spaceBarPressed = false;
    public GameObject[] Hearts;
    public AudioSource src;
    public AudioClip SearchAudio;
    public GameController gameController;

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
                if (Input.GetKeyDown(KeyCode.Space) && gameController.StudySessionFinished)
                {
                    src.clip = SearchAudio;
                    src.Play();
                }
                if (Input.GetKeyDown(KeyCode.Space) && !spaceBarPressed && gameController.StudySessionFinished)
                {
                    Debug.Log("Miss");
                    Searches--;
                    Debug.Log($"{Searches}");
                    spaceBarPressed = true;
                    Hearts[Searches].SetActive(false);                    
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    spaceBarPressed = false;
                }
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
                            SceneManager.LoadScene("SeekerWinsScene");
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
        if (Searches == 0)
        {
            SceneManager.LoadScene("HiderWinsScene");
        }
    }
}
