using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public GameObject dialogueHolder;
    public GameObject continueButton;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameDisplay;
    public Image dialoguePortrait;

    private void Awake()
    {
        instance = this;
    }

}

