using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravityScale = 1f;
    [SerializeField] float jumpTimer = 0.5f;

    bool pressedJump = false;
    bool releasedJump = false;
    bool startTimer = false;
    float timer;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        timer = jumpTimer;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            pressedJump = true;
        }

        if (Input.GetButtonUp("Jump")) 
        {
            releasedJump = true;
        }

        if (startTimer) 
        {
            timer -= Time.deltaTime;
            if (timer <= 0) 
            {
                releasedJump = true;
            }
        }
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
}
