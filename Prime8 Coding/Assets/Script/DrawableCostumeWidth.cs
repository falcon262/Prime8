using FreeDraw;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawableCostumeWidth : MonoBehaviour
{
	public Slider slider;

	private void OnEnable()
	{
		slider.value = Drawable.Pen_Width;
	}

	public void WidthChange()
	{
		Drawable.Pen_Width = (int)slider.value;
	}
}
