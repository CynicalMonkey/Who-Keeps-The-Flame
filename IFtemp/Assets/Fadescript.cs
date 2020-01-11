using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadescript : MonoBehaviour
{
    public static Fadescript Fref;
    public bool Fadein;
    public bool Stop;
    Color ThisColor;
        private void Awake()
    {
        ThisColor = GetComponent<Image>().color;
        Fref = this;
    }
    string Rule;
    public void LoadRule(string R)
    {
        Rule = R;
        Stop = false;
    }
    void Update()
    {
        if (!Stop)
        {

            if (Fadein)
            {
                if (ThisColor.a < 1)
                {
                    float F = ThisColor.a;
                    F += 0.1f;
                    ThisColor.a = F;
                }
                else
                {
                    Fadein = false;
                    UIManager.uiManager.Fadein(Rule);
                }
            }
            else
            {
                if (ThisColor.a > 0)
                {
                    float F = ThisColor.a;
                    F -= 0.05f;
                    ThisColor.a = F;
                }
                else
                {
                    Fadein = true;
                    Stop = true;
                   
                }
            }
            GetComponent<Image>().color=ThisColor;
        }
    }
}
