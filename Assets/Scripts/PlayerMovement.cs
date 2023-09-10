using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D collide;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        float velocityY = rigidBody.velocity.y;
        float velocityX = rigidBody.velocity.x;

        float newPosition = directionX * moveSpeed;
        rigidBody.velocity = new Vector2(newPosition, velocityY);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(velocityX, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        // Else statement is not required here because initial state is set
        MovementState state = MovementState.idle;

        if (directionX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }

        float verticalSpeed = rigidBody.velocity.y;
        if (verticalSpeed > .1f)
            state = MovementState.jumping;
        else if (verticalSpeed < -.1f)
            state = MovementState.falling;

        int stateValue = (int)state;
        animator.SetInteger("state", stateValue);
    }

    private bool IsGrounded()
    {
        Bounds bounds = collide.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
