using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float deathDuration = 1f;
    [SerializeField] string[] deathSoundNames;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float airMoveSpeed = 1;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] float jumpTimer = 0.5f;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius = .4f;

    float moveDirection;
    float gravityScale;

    bool pressedJump = false;
    bool releasedJump = false;
    bool heldJump = false;
    bool startTimer = false;
    float timer;

    bool isGrounded = false;
    bool isDead = false;

    Rigidbody2D rb;
    Collider2D playerCollider;
    PlayerAnimController animController;

    AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        playerCollider = GetComponent<Collider2D>();
        timer = jumpTimer;
        audioManager = GetComponent<AudioManager>();
        animController = GetComponent<PlayerAnimController>();
    }

    void Update()
    {
        GroundCheck();

        #region Move
        if (!isDead)
        {
            if (isGrounded)
            {
                moveDirection = moveSpeed * Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(moveDirection, rb.velocity.y);
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
                {
                    if (!audioManager.isPlaying("Footsies"))
                        audioManager.Play("Footsies");
                }
                else
                    audioManager.Stop("Footsies");
            }
            else
            {
                audioManager.Stop("Footsies");
                rb.AddForce(airMoveSpeed * Input.GetAxisRaw("Horizontal") * Vector2.right);
            }
        }
        else 
            audioManager.Stop("Footsies");
        #endregion

        #region Jump
        if (Input.GetButtonDown("Jump") && (heldJump || isGrounded))
        {
            audioManager.Play("Jump");
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

    public void Die()
    {
        isDead = true;
        playerCollider.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.velocity = Vector2.zero;
        audioManager.PlayRandom(deathSoundNames);
        animController.Die();
    }

    public float getDeathDuration()
    {
        return deathDuration;
    }
}
