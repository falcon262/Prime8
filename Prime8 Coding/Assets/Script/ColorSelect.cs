using System.Collections;
using System.Collections.Generic;
using FreeDraw;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelect : MonoBehaviour
{
    public Image currentColor;

    public void SetColor()
    {
        currentColor.color = this.transform.gameObject.GetComponent<Image>().color;
        Drawable.Pen_Colour = this.transform.gameObject.GetComponent<Image>().color;
    }
}
