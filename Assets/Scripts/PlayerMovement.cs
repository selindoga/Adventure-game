using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public LayerMask groundMask;
    public Joystick joystick;
    public Transform groundCheck;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public Transform groundCheck3;

    private Rigidbody2D rb;
    private Vector2 HorizontalMove;
    private float jHorizontal;
    private float jVertical;
    private float Sensitivity = 0.35f;
    private float movingSpeed = 150f;
    
    [SerializeField]
    private float groundDistance = 0.1f;
    
    [SerializeField]
    private bool isGrounded;

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
        

        if (isGrounded)
        {
            if (jHorizontal >= Sensitivity)
            {
                rb.velocity = HorizontalMove * Time.fixedDeltaTime * movingSpeed;
            } 
            else if (jHorizontal <= -Sensitivity)
            {
                rb.velocity = -HorizontalMove * Time.fixedDeltaTime * movingSpeed;
            }
        }
        
    }

    private void Update() // fixed update e almam gerekebilir
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask) || 
                     Physics2D.OverlapCircle(groundCheck1.position, groundDistance, groundMask) ||
                     Physics2D.OverlapCircle(groundCheck2.position, groundDistance, groundMask) ||
                     Physics2D.OverlapCircle(groundCheck3.position, groundDistance, groundMask);
    }
}
