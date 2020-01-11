using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour
{
    public static EngineScript engineScript;
    private void Awake()
    {
        engineScript = this;

    }
    public string[] Archive = new string[5];
    public bool Archivecheck(string S)
    {
        bool Check = false;
        int selection = -1;
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[i].UniqueID == S) { selection = i; }
        }
        if (selection > -1)

        {
            string Keyword = Pages[selection].Condition;
            if (Keyword == "None")
            {

                Check = true;
            }
            else
            {
                for (int i = 0; i < Archive.Length; i++)
                {
                    if (Archive[i] == Keyword) { Check = true; }
                }
            }
        }
       
        
       
        return Check;
    }
    public List<PageClass> Pages;

    public void Setup(string S)
    {
        int selection = -1;
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[i].UniqueID == S) { selection = i; }
        }
        if (selection > -1)
        {
            Actionpage(Pages[selection]);
        }
    }
    public void Actionpage(PageClass P)
    {
        typescript.Typescript.Load(P);
    }
    public OptionClass Ocgen(string S)
    {
        int selection = -1;
        OptionClass OC;
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[i].UniqueID == S) { selection = i; }
        }
        if (selection > -1)
        {
            OC = new OptionClass(Pages[selection]);
        }
        else
        {
            OC = null;
        }
        return OC;
    }
    public void Activate(string[] S)
    {
        if (S != null)
        {
            int i = 0;
            int.TryParse(S[0], out i);
            Archive[i] = S[1];
        }
    }
}
