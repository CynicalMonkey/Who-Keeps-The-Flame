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
    public Transform Menu;
    public Transform Gamescreen;
    public Transform Intro;
    public Transform Ending;
    public Text Introsig;
    public Text Introtext;
    public Text Endingtext;
    public Text EndingSig;

    void Wipe()
    {
        Gamescreen.gameObject.SetActive(false);
        Intro.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Ending.gameObject.SetActive(false);


    }
    public void Menuload()
    {
        Wipe();
        Fadescript.Fref.LoadRule("Menu");
    }
    public void Gameload()
    {
        Wipe();
        Fadescript.Fref.LoadRule("Intro");
       
    }

    public void Bookload()
    {
        if (typescript.Typescript.updating) { }
        else
        {
            Wipe();
            Fadescript.Fref.LoadRule("Game");

        }
    }
    public void Fadein(string S)
    {
        switch (S)
        {
            case "Menu":
                Menu.gameObject.SetActive(true);

                break;
            case "Intro":
                Intro.gameObject.SetActive(true);
                typescript.Typescript.Intro();
                break;
            case "Game":
            
                Gamescreen.gameObject.SetActive(true);
                EngineScript.engineScript.Setup("Menu");
                break;
        }
    }
}
