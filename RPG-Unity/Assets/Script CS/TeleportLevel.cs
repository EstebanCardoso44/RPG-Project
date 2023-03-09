using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLevel : MonoBehaviour
{
  public int sceneBuildIndex;
  // Start is called before the first frame update

  // Update is called once per frame

  void OnTriggerEnter2D(Collider2D other)//when collide teleport 
  {
    print("Vous entrer dans un donjon !");
    if (other.tag == "Player")
    {
      // Player entered, so move level
      print("Scène numéro " + sceneBuildIndex);
      SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
  }
}
