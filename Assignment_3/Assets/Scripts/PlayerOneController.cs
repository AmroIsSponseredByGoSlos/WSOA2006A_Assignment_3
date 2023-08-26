using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerOneController : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody rb;
    private float speed = 8.4f;
    private float RotationSpeed = 60;

    public void Start()
    {
        Player = gameObject;
        rb = Player.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("VerticalArrowKeys");
        float Rotation = Input.GetAxis("HorizontalArrowKeys");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        Quaternion rotation = Quaternion.Euler(0, Rotation * RotationSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }
}