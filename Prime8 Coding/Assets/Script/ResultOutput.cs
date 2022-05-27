using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultOutput : MonoBehaviour
{
    public TextMeshProUGUI output;
    
    public void Result(string result)
    {
        if (result == "0")
        {
            output.text = "false";
        }
        else if (result == "1")
        {
            output.text = "true";
        }
        else
        {
            output.text = result;
        }
        
    }
}
