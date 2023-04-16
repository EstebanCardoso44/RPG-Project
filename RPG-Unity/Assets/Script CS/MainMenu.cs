using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

  public GameObject playButton, backButtonLevel, backButtonCredits;
  public void Play()
  {
    SceneManager.LoadScene("Village1");
  }
  public void SelectDefault()
  {
    EventSystem.current.SetSelectedGameObject(playButton);
  }
  public void Levels()
  {
    EventSystem.current.SetSelectedGameObject(backButtonLevel);
  }
  public void Credits()
  {
    EventSystem.current.SetSelectedGameObject(backButtonCredits);
  }
  public void Level1() // Move to a certain scene
  {
    SceneManager.LoadScene("Village1");
  }
  public void Level2()
  {
    SceneManager.LoadScene("Dungeon1");
  }
  public void Quit() // quit game
  {
    Application.Quit();
  }
}
