using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Microsoft.Win32;

public class PlayerActions : MonoBehaviour
{
  // Start is called before the first frame update
  public float moveSpeed = 5f;
  public float collisionOffset = 0.05f;

  public int lastFacing;
  public ContactFilter2D movementFilter;
  Vector2 movement;
  Rigidbody2D rb;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
  Animator animator;
  SpriteRenderer spriteRenderer;
  public SwordAttack swordAttack;

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
    if (canMove)// if not doing animation who lock
    {
      if (movement != Vector2.zero)
      {
        bool success = TryMove(movement);
        if (success == false)//conditions allow us to slide 
        {
          success = TryMove(new Vector2(movement.x, 0));
        }
        if (success == false)
        {
          success = TryMove(new Vector2(0, movement.y));
        }
        animator.SetBool("IsMoving", success);// activate IsMoving , condition for our character to run 
      }
      else
      {
        animator.SetBool("IsMoving", false);// our char isn't running
      }
      if (movement.x < 0)// flip the char (side)
      {
        spriteRenderer.flipX = true;
        lastFacing = 1;
      }
      else if (movement.x > 0)
      {
        spriteRenderer.flipX = false;
        lastFacing = 2;
      }
      else if (movement.y > 0)
      {
        lastFacing = 3;
      }
      else if (movement.y < 0)
      {
        lastFacing = 4;
      }
    }
  }

  private bool TryMove(Vector2 direction)
  {
    if (direction != Vector2.zero)
    {
      int count = rb.Cast(
        direction,//direction where cast collider2D
        movementFilter, //filter result
        castCollisions, // array who receive result
      moveSpeed * Time.fixedDeltaTime + collisionOffset // distance cast collider
        );
      if (count == 0) // no collision so move 
      {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        //Time.fixedDeltaTime frame in time game ,
        // more accurate than irl time
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

  void OnMove(InputValue movementValue) // set our x/y when main character move 
  {
    movement = movementValue.Get<Vector2>();
    if (movement != Vector2.zero)
    {
      animator.SetFloat("XInput", movement.x);
      animator.SetFloat("YInput", movement.y);
    }

  }
  public void OnAttack() // Attack animation on trigger
  {
    animator.SetTrigger("Attack");
    swordAttack.swordCollider.enabled = true;
  }
  public void SwordAttack()
  {
    LockMove();
    /* if (movement.x == 0 && movement.y == 0)
     {
       switch (lastFacing)
       {
         case 1:
           swordAttack.AttackLeft();
           break;

         case 2:
           swordAttack.AttackRight();
           break;

         case 3:
           swordAttack.AttackUp();
           break;

         case 4:
           swordAttack.AttackDown();
           break;
       }
     }*/
    if (movement.x < 0)
    {
      swordAttack.AttackLeft();
    }
    else if (movement.x > 0)
    {
      swordAttack.AttackRight();
    }
    else if (movement.y < 0)
    {
      swordAttack.AttackDown();
    }
    else if (movement.y > 0)
    {
      swordAttack.AttackUp();
    }
  }
  public void SwordStop()
  {
    UnLockMove();
    swordAttack.AttackStop();
  }
  void LockMove() // lock to prevent attack while running
  {
    canMove = false;
  }
  void UnLockMove() // delock at the end of the animation ( done via adding event on the animation on Unity)
  {
    canMove = true;
  }

}

