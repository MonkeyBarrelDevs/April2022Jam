using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerModel;
    [SerializeField] float moveSpeed = 5f;
    
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravityScale = 1f;
    [SerializeField] float jumpTimer = 0.5f;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius = .4f;

    float moveDirection = 0f;

    bool pressedJump = false;
    bool releasedJump = false;
    bool heldJump = false;
    bool startTimer = false;
    float timer;

    bool isGrounded = false; 

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;

        timer = jumpTimer;
    }

    void Update()
    {
        GroundCheck();

        #region Move
        if (isGrounded) 
        {
            moveDirection = moveSpeed * Input.GetAxisRaw("Horizontal");
        }
        rb.velocity = new Vector2(moveDirection, rb.velocity.y);
        #endregion

        #region Jump
        if (Input.GetButtonDown("Jump") && (heldJump || isGrounded))
        {
            pressedJump = true;
            heldJump = true;
            
        }

        if (Input.GetButtonUp("Jump")) 
        {
            releasedJump = true;
            heldJump = false;
        }

        if (startTimer) 
        {
            timer -= Time.deltaTime;
            if (timer <= 0) 
            {
                releasedJump = true;
            }
        }
        #endregion
    }

    void FixedUpdate()
    {
        if (pressedJump) 
        {
            StartJump();
        }

        if (releasedJump) 
        {
            StopJump();
        }
    }

    void StartJump() 
    {
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
    }

    void StopJump() 
    {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }

    void GroundCheck() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckTransform.position, groundCheckRadius, groundLayer);
        isGrounded = colliders.Length > 0;
    }
}
