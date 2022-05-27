using System.Collections;
using System.Collections.Generic;
using AdvancedColorPicker;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchingColorPicker : MonoBehaviour
{
    public InputField colorHex;
    public ColorPicker picker;

    public void GetHex()
    {
        Color color = picker.CurrentColor;
        
        int r = (int)(color.r * 256);
        int g = (int)(color.g * 256);
        int b = (int)(color.b * 256);
        
        colorHex.text = string.Format ("{0:X2}{1:X2}{2:X2}", r, g, b);

    }

}
