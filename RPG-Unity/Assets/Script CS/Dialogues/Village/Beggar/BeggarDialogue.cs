using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//when the player collides with the beggar, he will be able to press the space bar to display the dialogue
public class BeggarDialogue : MonoBehaviour
{   
    // Start is called before the first frame update
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public GameObject player;
    public GameObject beggar;
    public GameObject beggarDialogue;
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(true);
            player.SetActive(false);
            beggar.SetActive(false);
            beggarDialogue.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    
}
