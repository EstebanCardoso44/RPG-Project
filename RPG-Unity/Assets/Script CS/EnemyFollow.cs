using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
   public float speed = 2f;
  public Transform target;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (target != null)// if target not in aggro , follow him
    {
      float step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }
  }
  private void OnTriggerEnter2D(Collider2D other) // enter in radius aggro
  {
    if (other.gameObject.tag == "Player")
    {
      target = other.transform;
    }
  }
  private void OnTriggerExit2D(Collider2D other)// leave radius aggro 
  {
    if (other.gameObject.tag == "Player")
    {
      target = null;
    }
  }
}
