using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FileButton : MonoBehaviour, IPointerClickHandler
{
    List<string> options;
    [SerializeField] TMP_Dropdown dropdown;

    private void Start()
    {
        options = new List<string>();

        options.Add("");
        options.Add("New");
        options.Add("Save Project");
        options.Add("Load Project");
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user right-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Right Clicked!");
        }

        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            /*foreach (var option in options)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = option });
            }*/
        }
    }
}
