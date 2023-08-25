using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerOneController : MonoBehaviour
{
    private GameObject Player;
    private float speed = 8.4f;
    private float RotationSpeed = 60;

    public void Start()
    {
        Player = gameObject;
    }

    public void Update()
    {
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float Rotation = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;
        transform.Translate(0, 0, moveVertical);
        transform.Rotate(0, Rotation, 0);
    }
}