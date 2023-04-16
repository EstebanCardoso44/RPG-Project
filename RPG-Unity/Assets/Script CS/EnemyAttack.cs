using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
  // Start is called before the first frame update

  [SerializeField] private float attackDamage = 10f;
  [SerializeField] private float attackSpeed = 1f;
  private float canAttack;
  void Start()
  {

  }
  void Update()
  {
  }
  private void OnTriggerStay2D(Collider2D other) // enter in radius aggro
  {
    if (other.gameObject.tag == "Player")
    {
      if (attackSpeed <= canAttack)
      {
        other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        canAttack = 0f;
      }
      else
      {
        canAttack += Time.deltaTime;
      }
    }
  }



  // Update is called once per frame

}
