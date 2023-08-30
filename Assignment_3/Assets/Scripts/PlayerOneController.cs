using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOneController : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody rb;
    private float speed = 17.4f;
    private float RotationSpeed = 120;
    public float Timer = 30f;
    public float Interval = 0f;
    public TextMeshProUGUI TimeText;
    public bool TimerActive = true;
    public Camera SeekerCamera;
    public Camera HiderCamera;
    public bool Started = false;
    public GameObject SeekerCanvas;
    public GameObject HiderCanvas;
    public bool ShownCanvas = false;
    public bool ShownGoHideCanvas = false;
    public GameController gameController;
    public bool HideTimeFinished = false;

    public void Start()
    {
        Player = gameObject;
        rb = Player.GetComponent<Rigidbody>();        
    }

    public void Update()
    {
        if (gameController.StudySessionFinished)
        {
            Rect HiderRect = new Rect(0f, 0f, 1f, 1f);
            HiderCamera.rect = HiderRect;
            Rect SeekerRect = new Rect(1f, 1f, 1f, 1f);
            SeekerCamera.rect = SeekerRect;
            if (ShownGoHideCanvas)
            {
                if (Timer != 0)
                {
                    if (Started)
                    {
                        if (Interval < 1f)
                        {
                            Interval += Time.deltaTime;
                        }
                        else
                        {
                            Timer--;
                            //TimeText.text = $"{Timer} Seconds Remaining";
                            Interval = 0f;
                        }
                    }
                }
                else
                {
                    TimerActive = false;
                    HideTimeFinished = true;
                    Rect newViewportRect = new Rect(0f, 0f, 1f, 1f);
                    SeekerCamera.rect = newViewportRect;
                    if (!ShownCanvas)
                    {
                        SeekerCanvas.SetActive(true);
                        ShownCanvas = true;
                    }
                }
            }
            else
            {
                HiderCanvas.SetActive(true);
                ShownGoHideCanvas = true;
            }
        }
            
    }
        

    public void FixedUpdate()
    {
        if (TimerActive)
        {
            float moveVertical = Input.GetAxis("VerticalArrowKeys");
            float Rotation = Input.GetAxis("HorizontalArrowKeys");
            Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
            Quaternion rotation = Quaternion.Euler(0, Rotation * RotationSpeed * Time.fixedDeltaTime, 0);
            rb.MoveRotation(rb.rotation * rotation);
        }
    }

    public void GoHide()
    {
        Started = true;
    }
}