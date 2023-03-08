using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject pauseMenu;
  void Start()
  {

  }

  // Update is called once per frame
  // || Input.GetButton("Start"))
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
      Time.timeScale = 0f;
    }
  }
  public void Resume()
  {
    pauseMenu.gameObject.SetActive(false);
    Time.timeScale = 1f;
  }
  public void MenuPrincipal()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("MainMenu");
  }
}
