using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class KeyIsPressed : BEInstruction
{

    KeyCode key;

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        try
        {
            string command = beBlock.BeInputs.stringValues[0];

            if (command == "Up Arrow")
            {
                command = "UpArrow";
            }
            else if (command == "Down Arrow")
            {
                command = "DownArrow";
            }
            else if (command == "Left Arrow")
            {
                command = "LeftArrow";
            }
            else if (command == "Right Arrow")
            {
                command = "RightArrow";
            }

            key = (KeyCode)System.Enum.Parse(typeof(KeyCode), command);
        }
        catch (Exception e)
        {
            Debug.Log("probably still initializing");
            Debug.Log(e);
        }

        if (Input.GetKeyDown(key))
        {
            beBlock.BeBlockGroup.isActive = true;
            BeController.PlayNextInside(beBlock);
        }
        else if (!Input.GetKeyDown(key))
        {
            beBlock.BeBlockGroup.isActive = false;
            BeController.StopGroup(beBlock.BeBlockGroup);
        }
    }

}
