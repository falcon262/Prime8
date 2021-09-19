using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FileButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject fileDrop;

    private void Start()
    {

    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            fileDrop.SetActive(true);
        }
    }
}
