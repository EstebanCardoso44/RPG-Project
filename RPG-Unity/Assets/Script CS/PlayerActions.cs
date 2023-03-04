using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerActions : MonoBehaviour
{
  public Rigidbody2D rb;
  public Transform groundCheck;
  public LayerMask groundLayer;

  public Animator animator;

  private float horizontal;
  private float speed = 2f;
  private float jumpingPower = 4f;
  private bool isFacingRight = true;

  void Update()
  {
    animator.SetFloat("Speed", Math.Abs(horizontal)); // link between our variable horizontal and our paramameters for animations in animator 

    if (!isFacingRight && horizontal > 0f)
    {
      Flip();
    }
    else if (isFacingRight && horizontal < 0f)
    {
      Flip();
    }
  }

  private void FixedUpdate()
  {
    rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
  }

  public void Jump(InputAction.CallbackContext context)
  {
    if (context.performed && IsGrounded())
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
      animator.SetBool("IsJumping", false);
    }

    if (context.canceled && rb.velocity.y > 0f)
    {
      rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
      animator.SetBool("IsJumping", true);
    }
  }

  private bool IsGrounded()
  {
    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
  }

  private void Flip()
  {
    isFacingRight = !isFacingRight;
    Vector3 localScale = transform.localScale;
    localScale.x *= -1f;
    transform.localScale = localScale;
  }

  public void Move(InputAction.CallbackContext context)
  {
    horizontal = context.ReadValue<Vector2>().x;
  }
  public void Attack(InputAction.CallbackContext context)
  {
    animator.SetTrigger("Attack");
  }
  public void Strike(InputAction.CallbackContext context)
  {
    animator.SetTrigger("Strike");
  }
  public void Cast(InputAction.CallbackContext context)
  {
    animator.SetTrigger("Cast");
  }
}