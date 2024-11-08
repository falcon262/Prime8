using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

public class MakeBlock : MonoBehaviour
{
    public GameObject InitialTextInput;

    public GameObject TextBlockInput;
    public GameObject NumberBlockInput;
    public GameObject StringBlockInput;
    public GameObject BooleanBlockInput;
    public Transform MoreBlocksParent;

    public BEController bEController;

    public List<GameObject> Blocks = new List<GameObject>();

    private void OnEnable()
    {
        foreach (var item in Blocks)
        {
            if(item.name != "Initial Block")
            Destroy(item.gameObject);
        }
        Blocks.Clear();
        InitialTextInput.GetComponent<TMP_InputField>().text = String.Empty;
        Blocks.Add(InitialTextInput);   
    }

    public void AddNewNumberInput()
    {
        if (!Blocks[Blocks.Count - 1].name.Contains("Number"))
        {
            GameObject numberBlockInput = Instantiate(NumberBlockInput, transform.position, Quaternion.identity);

            numberBlockInput.transform.SetParent(transform);

            numberBlockInput.GetComponent<RectTransform>().position =
               new Vector3(
               Blocks[Blocks.Count - 1].GetComponent<RectTransform>().position.x + 70,
               InitialTextInput.GetComponent<RectTransform>().position.y,
               InitialTextInput.GetComponent<RectTransform>().position.z
               );

            Blocks.Add(numberBlockInput);
        }
    }
    
    public void AddNewStringInput()
    {
        if (!Blocks[Blocks.Count - 1].name.Contains("String"))
        {
            GameObject stringBlockInput = Instantiate(StringBlockInput, transform.position, Quaternion.identity);

            stringBlockInput.transform.SetParent(transform);


            stringBlockInput.GetComponent<RectTransform>().position =
               new Vector3(
               Blocks[Blocks.Count - 1].GetComponent<RectTransform>().position.x + 70,
               InitialTextInput.GetComponent<RectTransform>().position.y,
               InitialTextInput.GetComponent<RectTransform>().position.z
               );

            Blocks.Add(stringBlockInput);

        }

    }

    public void AddNewBooleanInput()
    {
        if (!Blocks[Blocks.Count - 1].name.Contains("Bool"))
        {
            GameObject booleanBlockInput = Instantiate(BooleanBlockInput, transform.position, Quaternion.identity);

            booleanBlockInput.transform.SetParent(transform);


            booleanBlockInput.GetComponent<RectTransform>().position =
               new Vector3(
               Blocks[Blocks.Count - 1].GetComponent<RectTransform>().position.x + 70,
               InitialTextInput.GetComponent<RectTransform>().position.y,
               InitialTextInput.GetComponent<RectTransform>().position.z
               );

            Blocks.Add(booleanBlockInput);

        }

    }
    
    public void AddNewTextInput()
    {
        if (!Blocks[Blocks.Count - 1].name.Contains("Initial"))
        {
            GameObject textBlockInput = Instantiate(TextBlockInput, transform.position, Quaternion.identity);

            textBlockInput.transform.SetParent(transform);

            textBlockInput.GetComponent<RectTransform>().position =
               new Vector3(
               Blocks[Blocks.Count - 1].GetComponent<RectTransform>().position.x + 70,
               InitialTextInput.GetComponent<RectTransform>().position.y,
               InitialTextInput.GetComponent<RectTransform>().position.z
               );

            Blocks.Add(textBlockInput);

        }

    }

    public void OK()
    {
        var initialText = InitialTextInput.GetComponent<TMP_InputField>().text;

        string headerGuidline = "";

        foreach (var item in Blocks)
        {
            if (item.name == "Initial Block")
            {
                headerGuidline = headerGuidline + item.GetComponent<TMP_InputField>().text;
            }
            else if (item.name.Contains("Initial Block(Clone)"))
            {
                headerGuidline = headerGuidline + "\n" + item.GetComponent<TMP_InputField>().text;
            }
            else
            {
                headerGuidline = headerGuidline + "\n" + $"[inputfield = {item.GetComponent<TMP_InputField>().text}]";
            }
            
        }

        
        string instructionName = Regex.Replace(initialText, @"\s+", "");
        Color color = new Color(0.403921568627451f, 0.19215686274509805f, 0.403921568627451f, 1);

        if(!string.IsNullOrEmpty(instructionName) && !string.IsNullOrEmpty(headerGuidline))
        {
            Debug.Log(headerGuidline);
            Debug.Log(instructionName);
            bEController.BuildBlockTemplate(headerGuidline, instructionName, BEBlock.BlockTypeItems.simple, color, MoreBlocksParent);
            //bEController.ReimportInstructions();
        }

        
    }
}
