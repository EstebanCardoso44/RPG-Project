using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
  [SerializeField]
  string[] sentences;
  [SerializeField]
  string npcName;
  [SerializeField]
  Sprite npcPortrait;

  int index;
  bool isOnDialogue;
  bool canDialogue;

  HUDManager manager => HUDManager.instance;


  private void Update()
  {
    if (canDialogue && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton3)))
    {
      StartDialogue();
      manager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
      manager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { NextLine(); });
    }
    if (isOnDialogue && (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton0)))
    {
      NextLine();
    }

    if (isOnDialogue && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1)))
    {

      CloseDialogue();
    }
  }

  public void StartDialogue()
  {
    Debug.Log("Start Dialogue");
    manager.dialogueHolder.SetActive(true);
    isOnDialogue = true;
    TypingText(sentences);

  }

  void TypingText(string[] sentence)
  {
    manager.textDisplay.text = "";
    manager.nameDisplay.text = "";
    manager.dialoguePortrait.sprite = null;

    manager.nameDisplay.text = npcName;
    manager.textDisplay.text = sentence[index];
    manager.dialoguePortrait.sprite = npcPortrait;

    if (manager.textDisplay.text == sentence[index])
    {
      manager.continueButton.SetActive(true);
    }

  }

  public void NextLine()
  {
    manager.continueButton.SetActive(false);
    if (isOnDialogue && index < sentences.Length - 1)
    {
      index++;
      manager.textDisplay.text = "";
      TypingText(sentences);
    }
    else if (isOnDialogue && index == sentences.Length - 1)
    {
      isOnDialogue = false;
      index = 0;
      manager.textDisplay.text = "";
      manager.nameDisplay.text = "";
      manager.dialoguePortrait.sprite = null;
      manager.dialogueHolder.SetActive(false);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      canDialogue = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      canDialogue = false;
    }
  }

  //close dialogue
  public void CloseDialogue()
  {
    manager.dialogueHolder.SetActive(false);
    isOnDialogue = false;
    canDialogue = true;
    index = 0;
    manager.textDisplay.text = "";
    manager.nameDisplay.text = "";
    manager.dialoguePortrait.sprite = null;
  }


}
