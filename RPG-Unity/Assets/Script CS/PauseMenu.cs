using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject resumeButton, commandButton, closeButton, mainMenu;
  public GameObject pauseMenu;

  void Start()
  {
  }

  // Update is called once per frame

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) //key pressed activate code
    {
      pauseMenu.SetActive(true); // active PauseMenu in game
      Time.timeScale = 0f; //Freeze game
    }
  }
  public void Resume()//unfreeze + disapear menu
  {
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
    EventSystem.current.SetSelectedGameObject(resumeButton);
  }
  public void CloseButton()
  {
    EventSystem.current.SetSelectedGameObject(closeButton);
  }
  public void Command()
  {
    EventSystem.current.SetSelectedGameObject(commandButton);
  }
  public void MenuPrincipal() //get to main menu from pause menu
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("MainMenu");
    EventSystem.current.SetSelectedGameObject(mainMenu);
  }
}
