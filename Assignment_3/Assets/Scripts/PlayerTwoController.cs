using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
                        //TimeText.text = $"{Timer} Seconds Remaining";
                        Interval = 0f;
                    }
                }
            }
            else
            {
                TimerActive = false;
            }
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
}