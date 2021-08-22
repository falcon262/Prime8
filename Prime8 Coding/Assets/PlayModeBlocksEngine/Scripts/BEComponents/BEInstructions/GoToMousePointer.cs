using UnityEngine;
using System.Collections;

public class GoToMousePointer : BEInstruction
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
		targetObject.transform.localPosition = Input.mousePosition;
		BeController.PlayNextOutside(beBlock);
	}
 
}
