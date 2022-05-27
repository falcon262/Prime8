using UnityEngine;
using System.Collections;
using System;

public class SenseKey : BEInstruction
{
	KeyCode key;
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		
		// Use "beBlock.BeInputs" to get the input values
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

        if (Input.GetKey(key))
        {
            result = "1";
        }
        else if (!Input.GetKey(key))
        {
            result = "0";
        }
		
		Debug.Log(result);
		return result;
	}
	
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		// Use "beBlock.BeInputs" to get the input values
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
