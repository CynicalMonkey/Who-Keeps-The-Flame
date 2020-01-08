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
}
