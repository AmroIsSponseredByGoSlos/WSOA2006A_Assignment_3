using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public RectTransform StopWatch;
    public bool ShowingTime = false;
    public bool isMoving;
    public Vector3 targetPosition;
    public GameObject pauseUI;
    public bool isPaused = false;

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
                            TimeText.text = $"{Timer}";
                            Interval = 0f;
                        }
                    }
                }
                else
                {
                    TimerActive = false;
                    HideTimeFinished = true;
                    targetPosition = new Vector3(198f, -394.4f, -1.67f);
                    isMoving = true;
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

        if (Input.GetMouseButtonDown(1) && !HideTimeFinished && gameController.StudySessionFinished)
        {
            if (!isMoving)
            {
                if (!ShowingTime)
                {
                    targetPosition = new Vector3(198f, -94.4f, -1.67f);
                    ShowingTime = true;
                }
                else
                {
                    targetPosition = new Vector3(198f, -394.4f, -1.67f);
                    ShowingTime = false;
                }

                isMoving = true;
            }
        }

        if (isMoving)
        {
            float step = 550f * Time.deltaTime; 
            StopWatch.localPosition = Vector3.MoveTowards(StopWatch.localPosition, targetPosition, step);
            if (Vector3.Distance(StopWatch.localPosition, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !HideTimeFinished && gameController.StudySessionFinished)
        {
            TogglePause();
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

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false); 
        }
    }

    public void OnContinueClick()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene("IntroScene");
        Time.timeScale = 1;
    }

    public void OnEndClick()
    {
        Application.Quit();
    }
}