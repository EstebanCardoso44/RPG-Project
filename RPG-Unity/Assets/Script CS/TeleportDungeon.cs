using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportDungeon : MonoBehaviour
{
  public int sceneBuildIndex;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    void OnTriggerEnter2D(Collider2D other)
    {
      print("Vous entrer dans un donjon !");
      if (other.tag == "Player")
      {
        // Player entered, so move level
        print("Switching Scene to " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
      }
    }
  }
}
