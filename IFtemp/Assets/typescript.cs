using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typescript : MonoBehaviour
{
    public static typescript Typescript;
    void Awake()
    {
        Typescript = this;
    }
    string Basetext;
    public bool updating;
    string Choppedtext;
    public string Outputtext;
    public GameObject Optionprefab;
    public float writespeed=0.1f;
    int writelength=1;
    private void FixedUpdate()
    {
        if (updating)
        {
            if (Input.GetMouseButtonDown(0))
            {
                writespeed = 0f;
                writelength = 2;
            }
            if (Input.GetMouseButtonUp(0))
            {
                writespeed = 0.05f;
                writelength = 1;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Outputtext = Basetext;
                Choppedtext = " ";
            }
            
        }
    }
    public void Load(PageClass P)
    {


        updating = true;
        StartCoroutine(Typepage(P));

    }
    public string NextChar()
    {
        string N = "";
        if (Choppedtext.ToCharArray().Length > 1)
        {
            N = Choppedtext.Substring(0, writelength);
            Choppedtext = Choppedtext.Substring(writelength);

        }
        else
        {
            N = Choppedtext.Substring(0, 1);
            Choppedtext = Choppedtext.Substring(1);

        }


        return N;
    }
    public void Intro()
    {
        StartCoroutine(Typeintro());
    }
    IEnumerator Typepage(PageClass P)
    {
        writespeed = 0.1f;
        Basetext = P.ContentTitle;
        Choppedtext = Basetext;
        Outputtext = "";
        UIManager.uiManager.DialogueTitle.text = Outputtext;
        UIManager.uiManager.Dialoguebox.text = Outputtext;
        UIManager.uiManager.Action.text = Outputtext;
        foreach (Transform item in UIManager.uiManager.OptionHolder)
        {
            Destroy(item.gameObject);
        }
        while (Choppedtext.Length > 0)
        {

            Outputtext += NextChar();
            UIManager.uiManager.DialogueTitle.text = Outputtext;
            yield return new WaitForSeconds(writespeed);

        }
        Basetext = P.Content;
        Choppedtext = Basetext;
        Outputtext = "";
        while (Choppedtext.Length > 0)
        {
            Outputtext += NextChar();
            UIManager.uiManager.Dialoguebox.text = Outputtext;
            yield return new WaitForSeconds(writespeed);
        }
        for (int i = 0; i < P.Options.Count; i++)
        {
            if (EngineScript.engineScript.Archivecheck(P.Options[i]))
            {
                GameObject Button = Instantiate(Optionprefab);
                buttonscript OC = Button.GetComponent<buttonscript>();
                OptionClass OCG = EngineScript.engineScript.Ocgen(P.Options[i]);
                OC.setup(OCG);
                Button.transform.SetParent(UIManager.uiManager.OptionHolder);
                yield return new WaitForSeconds(0.5f);
            }
        }
        Basetext = P.CallToAction;
        Choppedtext = Basetext;
        Outputtext = "";
        while (Choppedtext.Length > 0)
        {
            Outputtext += NextChar();
            UIManager.uiManager.Action.text = Outputtext;
            yield return new WaitForSeconds(writespeed);
        }
        
        updating = false;
    }
    public IEnumerator Typeintro()
    {
        updating = true;
        string sigtext = UIManager.uiManager.Introsig.text;
        UIManager.uiManager.Introsig.text = "";
        Basetext = UIManager.uiManager.Introtext.text;
        Choppedtext = Basetext;
        Outputtext = "";
        UIManager.uiManager.Introtext.text = Outputtext;
        while (Choppedtext.Length > 0)
        {

            Outputtext += NextChar();
            UIManager.uiManager.Introtext.text = Outputtext;
            yield return new WaitForSeconds(writespeed);

        }
        Basetext = sigtext;
        Choppedtext = Basetext;
        Outputtext = "";

        while (Choppedtext.Length > 0)
        {
            Outputtext += NextChar();
            UIManager.uiManager.Introsig.text = Outputtext;
            yield return new WaitForSeconds(writespeed);
        }
        updating = false;
    }
}
