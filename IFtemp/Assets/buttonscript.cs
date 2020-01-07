using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscript : MonoBehaviour
{
    public OptionClass Option;
    public string Button;

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
}
