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
    private Vector2 lowestGroundCheck;
    private Vector3[] groundCheckArray = new Vector3[4];
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
        
        groundCheckArray [0] = groundCheck.position;
        groundCheckArray [1] = groundCheck1.position;
        groundCheckArray [2] = groundCheck2.position;
        groundCheckArray [3] = groundCheck3.position;
        
        isGrounded = Physics2D.OverlapCircle( FindLowestGroundCheck(groundCheckArray), groundDistance, groundMask);
        

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

    private Vector3 FindLowestGroundCheck(Vector3[] vectorArray)
    {
        Vector3 _vector = new Vector3(0,1000,0);
        foreach (var vector in vectorArray)
        {
            if (vector.y < _vector.y)
                _vector = vector;
        }
        return _vector;
    }
}
