using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Sensitivity = 0.35f;

    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 HorizontalMove;

    private float jHorizontal;
    private float jVertical;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        HorizontalMove = new Vector2(1f, 0f);
    }
    void FixedUpdate()
    {
        jHorizontal = joystick.Horizontal;
        jVertical = joystick.Vertical;
        
        // Rigidbody2D.velocity is good with dynamic
        // Rigidbody2D.MovePosition is good with kinematic
        
        if (jHorizontal >= Sensitivity)
        {
            rb.velocity = HorizontalMove;
        } 
        else if (jHorizontal <= -Sensitivity)
        {
            rb.velocity = -HorizontalMove;
        }
    }
}
