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
  
    public void Load(PageClass P)
    {
      
        
        updating = true;
        StartCoroutine(Typepage(P));
      
    }
    public string NextChar()
    {
        string N = "";
        char[] chars = Choppedtext.ToCharArray();
        N = Choppedtext.Substring(0, 1);
        Choppedtext = Choppedtext.Substring(1);
      
        return N;
    }
    IEnumerator Typepage(PageClass P)
    {
        Basetext = P.Title;
        Choppedtext = Basetext;
        Outputtext = "";
        while (Choppedtext.Length > 0)
        {
            Outputtext += NextChar();
            UIManager.uiManager.DialogueTitle.text = Outputtext;
            yield return new WaitForSeconds(0.06f);
        }
        Basetext = P.Textpage;
        Choppedtext = Basetext;
        Outputtext = "";
        while (Choppedtext.Length > 0)
        {
            Outputtext += NextChar();
            UIManager.uiManager.Dialoguebox.text = Outputtext;
            yield return new WaitForSeconds(0.03f);
        }
        Basetext = P.Action;
        Choppedtext = Basetext;
        Outputtext = "";
        while (Choppedtext.Length > 0)
        {
            Outputtext += NextChar();
            UIManager.uiManager.Action.text = Outputtext;
            yield return new WaitForSeconds(0.03f);
        }
        updating = false;
    }
  
}
