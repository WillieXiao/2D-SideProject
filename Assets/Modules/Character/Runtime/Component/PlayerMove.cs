using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    [SerializeField]
    private float characterSpeed = 0f;
    [SerializeField]
    private float jumpForce = 0f;
    [SerializeField] 
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius = .2f;
    [SerializeField]
    private LayerMask whatIsGround;

    private bool facingRight = true;
    private bool isGrounded;
    private bool isLockMove;
    private int airJumpCount = 1;
    private Vector2 m_Velocity = Vector2.zero;

    public Subject<bool> LandingEvent = new Subject<bool>();
    public Subject<Unit> FallingEvent = new Subject<Unit>();

    public Subject<Unit> PlayAirJumpAnimationEvent = new Subject<Unit>();
    public Subject<Unit> PlayGeneralJumpAnimationEvent = new Subject<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    public void SetLockMove(bool lockMove)
    {
        isLockMove = lockMove;
    }
    public void OnMove(Vector2 moveDirection)
    {
        if (isLockMove == true)
            return;

        if (moveDirection.x > 0 && !facingRight)
        {
            Flip();
        }
        if (moveDirection.x < 0 && facingRight)
        {
            Flip();
        }
        Vector2 targetVelocity = new Vector2(moveDirection.x * characterSpeed, rigidbody.velocity.y);
        rigidbody.velocity = targetVelocity;

    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnJump()
    {
        if (isGrounded == false && airJumpCount<=0)
            return;
        if(isGrounded == false && airJumpCount > 0)
        {
            rigidbody.velocity = Vector2.zero;
            PlayAirJumpAnimationEvent.OnNext(Unit.Default);
            airJumpCount--;
        }
        else if(isGrounded == true)
        {
            PlayGeneralJumpAnimationEvent.OnNext(Unit.Default);
        }
        rigidbody.AddForce(new Vector2(0f,jumpForce));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                {
                    LandingEvent.OnNext(true);
                    airJumpCount = 1;
                }
                   
            }
        }

        if (isGrounded == false && rigidbody.velocity.y < 0f)
        {
            FallingEvent.OnNext(Unit.Default);
        }
    }
}
