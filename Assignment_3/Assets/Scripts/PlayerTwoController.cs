using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerTwoController : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody rb;
    private float speed = 17.4f;
    private float RotationSpeed = 120;
    public float Timer = 30f;
    public float Interval = 0f;
    public TextMeshProUGUI TimeText;
    public bool TimerActive = true;
    public bool Started = false;
    public PlayerOneController playerOneController;
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
        if (playerOneController.HideTimeFinished)
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
                SceneManager.LoadScene("HiderWinsScene");
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (!isMoving)
                {
                    if (!ShowingTime)
                    {
                        targetPosition = new Vector3(167f, -88f, 0);
                        ShowingTime = true;
                    }
                    else
                    {
                        targetPosition = new Vector3(167f, -324f, 0f);
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
        }

        if (Input.GetKeyDown(KeyCode.Escape) && playerOneController.HideTimeFinished)
        {
            TogglePause();
        }

    }

    public void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("VerticalLetterKeys");
        float Rotation = Input.GetAxis("HorizontalLetterKeys");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        Quaternion rotation = Quaternion.Euler(0, Rotation * RotationSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }

    public void GoSeek()
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
}