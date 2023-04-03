using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
  Animator animator;
  // Start is called before the first frame update
  public float health = 100f;
  public float maxHealth = 100f;
  public int scene;
  void Start()
  {
    animator = GetComponent<Animator>();
    health = maxHealth;
  }
  public void UpdateHealth(float mod)
  {
    health += mod;
    if (health > maxHealth)
    {
      health = maxHealth;
    }
    else if (health <= 0)
    {
      health = 0f;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (health == 0f)
    {
      OnDie();
    }

  }
  public void OnDie() // Die animation on trigger
  {
    animator.SetTrigger("Die");
  }
  public void ReSpawn()
  {
    int scene = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(scene, LoadSceneMode.Single);
  }
}
