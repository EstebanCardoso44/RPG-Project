using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public Image fillBar;
  public PlayerHealth playerHealth;
  private Slider slider;

  // Start is called before the first frame update
  void Start()
  {
    slider = GetComponent<Slider>();
  }

  // Update is called once per frame
  void Update()
  {
    if (slider.value <= slider.minValue)
    {
      fillBar.enabled = false;
    }
    if (slider.value > slider.minValue && !fillBar.enabled)
    {
      fillBar.enabled = true;
    }
    float fillValue = playerHealth.health / playerHealth.maxHealth;
    slider.value = fillValue;
  }
}
