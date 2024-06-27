using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI Scoreright;
    public TextMeshProUGUI Scoreleft;


    public void SetScoreleftText(string text)
    {

        Scoreleft.SetText(text);
    }

    public void SetScorerightText(string text)
    {

        Scoreleft.SetText(text);
    }
}
