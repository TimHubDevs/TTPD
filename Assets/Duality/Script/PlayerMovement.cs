using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    short sndgrnd = 1;
    FMOD.Studio.EventInstance jumpdwnInstance;

    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    public Animator animator;

    public GameObject head;
    public GameObject body;
    public GameObject player;
    public bool isHiding=false;
    public bool isReversedGrav;
    public bool isBlack=false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isReversedGrav = false;
        if (isBlack)
        {
            ChangeGravity();
        }
    }
    void Update()
    {
        

        Move();
        if (!isReversedGrav)
        {
            Jump();
            BetterJump();
        }
        else
        {
            JumpG();
            BetterJumpG();
        }
        CheckIfGrounded();
        Hide();
    }
    public void ChangeGravity()
    {
        if (isReversedGrav)
        {
            isReversedGrav = false;
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            player.transform.Rotate(new Vector3(0, 180, 180));
        }
        else
        {
            isReversedGrav = true;
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            player.transform.Rotate(new Vector3(0, 180, 180));
        }

    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0) 
            animator.SetBool("isMoving",true);
        else
            animator.SetBool("isMoving", false);
        if (x < 0)
        {
            head.GetComponent<SpriteRenderer>().flipX = false;
            body.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x > 0)
        {
            head.GetComponent<SpriteRenderer>().flipX = true;
            body.GetComponent<SpriteRenderer>().flipX = false;
        }
        float moveBy = x * speed;
        if(!isHiding)
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;

    }
    void Hide()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isHiding&& isGrounded)
        {
            animator.SetBool("isHiding", true);
            isHiding = true;
            rb.velocity = Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.S) && isHiding)
        {
            animator.SetBool("isHiding",false);
            StartCoroutine(SetHidingFalse());
        }
    }
    IEnumerator SetHidingFalse()
    {
        do
        {
            yield return null;
        } while (animator.GetCurrentAnimatorStateInfo(0).IsName("UnHide")|| animator.GetCurrentAnimatorStateInfo(0).IsName("Hide"));
       
        isHiding = false;
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
            animator.SetBool("isFalling", true);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void JumpG()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isHiding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            animator.SetBool("isJumping", true);
        }
    }
    void BetterJumpG()
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * -Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            animator.SetBool("isFalling", true);
        }
        else if (rb.velocity.y < 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * -Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
    

        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            while (sndgrnd <= 1)
                
            { 
                

                jumpdwnInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/JumpDown");
                jumpdwnInstance.start();
                jumpdwnInstance.release();

                sndgrnd++;
            } 
   
        }
        else
        {
            isGrounded = false;
            sndgrnd = 1;
        }
    }
}
