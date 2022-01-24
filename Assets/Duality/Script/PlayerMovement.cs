using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    Animator animator;

    public GameObject head;
    public bool isHiding=false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
        Hide();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0) 
            animator.SetBool("isMoving",true);
        else
            animator.SetBool("isMoving", false);
        if (x < 0)
            head.GetComponent<SpriteRenderer>().flipX = false;
        else if(x>0)
            head.GetComponent<SpriteRenderer>().flipX = true;
        float moveBy = x * speed;
        if(!isHiding)
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;

    }
    void Hide()
    {
        if (Input.GetKeyDown(KeyCode.H) && !isHiding&& isGrounded)
        {
            animator.SetBool("isHiding", true);
            isHiding = true;
            rb.velocity = Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.H) && isHiding)
        {
            animator.SetBool("isHiding",false);
            isHiding = false;
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isHiding)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
        }
    }
}
