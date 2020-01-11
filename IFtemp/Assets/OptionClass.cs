using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionClass 
{
    public string Title;
    public string Option;
    public string Condition;
    public string[] Action = new string[2];
    public OptionClass(PageClass P)
    {
        Title = P.OptionTitle;
        Option = P.UniqueID;
        Condition = P.Condition;
        Action = P.Action;
    }
}
