using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;
    private void Awake()
    {
        uiManager = this;
    }
    public Text Dialoguebox;
    public Text DialogueTitle;
    public Text Action;
    public Transform OptionHolder;
}
