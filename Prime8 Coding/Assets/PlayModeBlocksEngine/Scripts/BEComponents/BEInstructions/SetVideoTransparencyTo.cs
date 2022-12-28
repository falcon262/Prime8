using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetVideoTransparencyTo : BEInstruction
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
		if(targetObject.gameManager.isCamOn == true)
		{
            targetObject.gameManager.background.GetComponent<Image>().color = new Color(1, 1, 1, beBlock.BeInputs.numberValues[0] / 100);
            Debug.Log(beBlock.BeInputs.numberValues[0]/100);
		}
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
