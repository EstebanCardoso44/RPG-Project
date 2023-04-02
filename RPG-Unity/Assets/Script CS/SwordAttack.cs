using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
  Animator animator;
  public Collider2D swordCollider;

  Vector2 attackPos;

  public float damage = 30;


  void Start()
  {
    attackPos = transform.localPosition;
  }
  void Update()
  {


  }

  public void AttackRight()
  {
    print("attack right");
    swordCollider.enabled = true;
    transform.localPosition = attackPos;
  }
  public void AttackLeft()
  {
    print("attack left");
    swordCollider.enabled = true;
    transform.localPosition = new Vector3(attackPos.x - 0.15f, attackPos.y);
  }
  public void AttackUp()
  {
    print("attack up");
    swordCollider.enabled = true;
    transform.localPosition = new Vector3(attackPos.x - 0.09f, attackPos.y + 0.10f);
  }
  public void AttackDown()
  {
    print("attack down");
    swordCollider.enabled = true;
    transform.localPosition = new Vector3(attackPos.x - 0.09f, attackPos.y - 0.10f);
  }
  public void AttackStop()
  {
    swordCollider.enabled = false;
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Enemy")
    {
      EnemyDie enemy = other.GetComponent<EnemyDie>();
      if (enemy != null)
      {
        enemy.Health -= damage;
      }
    }
  }
}
