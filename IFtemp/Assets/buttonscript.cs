using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonscript : MonoBehaviour
{
    OptionClass Option;
    string Button;
    public Text ButtonWord;

    public void PRESS()
    {
        if (typescript.Typescript.updating)
        {
            
        }
        else
        {
            EngineScript.engineScript.Setup(Button);
        }
    }

    public void setup(OptionClass OC)
    {
        Option = OC;
        Button = OC.Option;
        ButtonWord.text = OC.Title;

    }
}
