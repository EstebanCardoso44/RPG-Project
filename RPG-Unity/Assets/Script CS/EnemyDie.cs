using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
  // Start is called before the first frame update

  public float health = 100;
  public float Health
  {
    set
    {
      health = value;
      if (health <= 0)
      {
        Die();
      }
    }
    get
    {
      return health;
    }
  }


  public void Die()
  {
    Destroy(transform.parent.gameObject);
  }
}
