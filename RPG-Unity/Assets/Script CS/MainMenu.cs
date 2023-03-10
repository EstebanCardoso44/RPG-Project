using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Play()
  {
    SceneManager.LoadScene("Village1");
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
