using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
  // Start is called before the first frame update
  public float moveSpeed = 1f;
  public float collisionOffset = 0.05f;
  public ContactFilter2D movementFilter;
  Vector2 movement;
  Rigidbody2D rb;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
  Animator animator;
  SpriteRenderer spriteRenderer;

  bool canMove = true;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void FixedUpdate()
  {
    if (canMove)
    {
      if (movement != Vector2.zero)
      {
        bool success = TryMove(movement);
        if (!success)
        {
          success = TryMove(new Vector2(movement.x, 0));

          if (!success)
          {
            success = TryMove(new Vector2(movement.y, 0));
          }
        }
        animator.SetBool("IsMoving", success);
      }
      else
      {
        animator.SetBool("IsMoving", false);
      }
      if (movement.x < 0)
      {
        spriteRenderer.flipX = true;
      }
      else if (movement.x > 0)
      {
        spriteRenderer.flipX = false;
      }
    }
  }




  private bool TryMove(Vector2 direction)
  {
    if (direction != Vector2.zero)
    {
      int count = rb.Cast(
        direction,
        movementFilter,
        castCollisions,
      moveSpeed * Time.fixedDeltaTime + collisionOffset
        );
      if (count == 0)
      {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        return true;
      }
      else
      {
        return false;
      }
    }
    else
    {
      return false;
    }
  }

  void OnMove(InputValue movementValue)
  {
    movement = movementValue.Get<Vector2>();

  }
  void OnAttackSide()
  {
    animator.SetTrigger("AttackSide");
  }

  void LockMove()
  {
    canMove = false;
  }
  void UnLockMove()
  {
    canMove = true;
  }

}

