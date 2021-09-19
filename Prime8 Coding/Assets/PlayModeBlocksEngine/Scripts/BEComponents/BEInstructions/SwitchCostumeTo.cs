using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using System.Collections;

public class SwitchCostumeTo : BEInstruction
{
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		
		// Use "beBlock.BeInputs" to get the input values
		
		return result;
	}
	
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
        // Use "beBlock.BeInputs" to get the input values
        foreach (GameObject costume in targetObject.GetComponent<UIController>().newCostume)
        {
            if (costume.GetComponentInChildren<Image>().sprite.name == beBlock.BeInputs.stringValues[0])
            {
				costume.GetComponent<LeanToggle>().TurnOn();
            }
        }
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
