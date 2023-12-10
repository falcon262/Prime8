using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Gui;
using UnityEngine.UI;

public class SelectedCharacterName : MonoBehaviour
{
    public TMP_InputField textInput;
    
    UIController controller;

    // Start is called before the first frame update
    void Start()
    {
		controller = FindObjectOfType<UIController>();
	}

	private void OnEnable()
	{
		
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    public void ChangeCotumeName()
    {
        foreach (var item in controller.newCostume)
        {
            if (item.GetComponent<LeanToggle>().On)
            {
                Debug.Log(item.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name);

                //item.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name = textInput.text;

                controller.newCostumeNames[controller.newCostumeNames.IndexOf(item.GetComponentInChildren<TextMeshProUGUI>().text)] = textInput.text;

                item.GetComponentInChildren<TextMeshProUGUI>().text = textInput.text;




                /*foreach (Transform child in controller.LooksBlocks.transform)
                {
                    if (child.name == "SwitchCostumeTo")
                    {
                        child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options
                             .Find(x => x.text == item.GetComponentInChildren<Image>().sprite.name || x.text == textInput.text).text = textInput.text;

                    }
                }*/
                //item.GetComponentInChildren<Image>().sprite.name = textInput.text;

                //item.GetComponentInChildren<TextMeshProUGUI>().text = textInput.text;
            }
        }
    }
}
