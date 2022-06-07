using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private int extraJumps;
    public int extraJumpsValue;

    Animator animator;
    private bool isJumping;



    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (animator)
        {
            animator.SetBool("Run", Mathf.Abs(moveInput) >= 0.01);//
        }
        

        if(facingRight == false && moveInput>0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Update()
    {
        isJumping = isGrounded;
        if (!isJumping && !isGrounded)
        {
            animator.SetTrigger("Fall");
        }


        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            if (animator)
            {
                isJumping = true;
                animator.SetTrigger("Jump");        
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }


    }

}
