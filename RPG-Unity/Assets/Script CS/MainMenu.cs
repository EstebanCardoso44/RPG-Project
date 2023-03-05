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
    {

    }

  }
  public void Quit()
  {
    Application.Quit();
  }
}
