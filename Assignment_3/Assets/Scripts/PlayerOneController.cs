using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerOneController : MonoBehaviour
{
    private GameObject Player;
    private float speed = 2.4f;

    public void Start()
    {
        Player = gameObject;
    }

    public void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveVertical);
        transform.Translate(Vector3.right * Time.deltaTime * speed * moveHorizontal);
    }
}