using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public LayerMask groundMask;
    public Transform groundCheck;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public Transform groundCheck3;

    private Rigidbody2D rb;
    private Vector2 HorizontalMove;
    private Vector2 VerticalMove;
    private Vector2 lowestGroundCheck;
    private float jHorizontal;
    //private float jVertical;
    private float Sensitivity = 0.35f;
    private float movingSpeed = 70f;
    private float jumpingSpeed = 10f;
    private float groundDistance = 0.1f;
    private Vector3[] groundCheckArray = new Vector3[4];
    
    [SerializeField]
    private bool isGrounded;

    public TouchPhase touch;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        HorizontalMove = new Vector2(1f, 0f);
        VerticalMove = new Vector2(0f, 1f);
    }
    void FixedUpdate()
    {
        jHorizontal = joystick.Horizontal;
        // jVertical = joystick.Vertical;
        
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

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = VerticalMove * jumpingSpeed;
        }
    }
}
