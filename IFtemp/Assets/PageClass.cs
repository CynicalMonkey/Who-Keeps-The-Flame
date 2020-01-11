using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PageClass 
{
    public string UniqueID;
    public string ContentTitle;
    public string OptionTitle;
    public string Content;
    public string Condition;
    public string[] Action = new string[2];
    public string CallToAction;
    public List<string> Options;
    
    public PageClass()
    {

    }
  
}
