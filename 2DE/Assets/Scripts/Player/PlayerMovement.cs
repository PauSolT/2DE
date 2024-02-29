using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction jumpAction;
    private InputAction moveAction;
    private Rigidbody2D rb;

    private CapsuleCollider2D coll;

    private float jumpForce = 20f;
    private float moveSpeed = 7f;
    private float direction;

    private readonly float coyoteTime = 0.1f;
    private float currentCoyoteTime = 0f;

    private readonly float jumpBuffering = 0.25f;
    private float currentJumpBuffer = 0f;

    private readonly int jumpableGround = 1 << 3;
    //private readonly int jumpableGround = 1 << 3 | 1 << 6 | 1 << 7 | 1 << 8;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        coll = GetComponent<CapsuleCollider2D>();
        jumpAction = playerInput.actions["Jump"];
        moveAction = playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        jumpAction.performed += Jump;
        moveAction.performed += Move;
        moveAction.canceled += CancelMove;
    }

    private void OnDisable()
    {
        jumpAction.performed -= Jump;
        moveAction.performed -= Move;
        moveAction.canceled -= CancelMove;
    }

    private void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<float>();
    }

    private void CancelMove(InputAction.CallbackContext context)
    {
        direction = 0;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        currentJumpBuffer = jumpBuffering;
        TryToJump();
    }


    private void TryToJump()
    {
        if (currentJumpBuffer > 0f && IsGrounded() || currentCoyoteTime > 0f && !IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentCoyoteTime = 0f;
            currentJumpBuffer = 0f;
        }
        else if (Mathf.Approximately(currentJumpBuffer, 0))
        {
            currentJumpBuffer = jumpBuffering;
        }
    }

    private bool IsGrounded()
    {
        Vector2 capsuleCenter = coll.bounds.center;
        Vector2 capsuleSize = coll.bounds.size;

        RaycastHit2D hit = Physics2D.CapsuleCast(capsuleCenter, capsuleSize, CapsuleDirection2D.Vertical, 0f, Vector2.down, 0.1f, jumpableGround);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void FixedUpdate()
    {
        if (currentJumpBuffer > 0f)
        {
            currentJumpBuffer -= Time.fixedDeltaTime;
        }
        if (currentJumpBuffer > 0f)
        {
            TryToJump();
        }

        if (IsGrounded())
        {
            currentCoyoteTime = coyoteTime;
        }
        else if (!IsGrounded() && currentCoyoteTime > 0f)
        {
            currentCoyoteTime -= Time.deltaTime;
        }
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
    }

}