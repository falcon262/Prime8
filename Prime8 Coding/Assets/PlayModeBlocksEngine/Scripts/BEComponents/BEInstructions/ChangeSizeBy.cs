using UnityEngine;
using System.Collections;

public class ChangeSizeBy : BEInstruction
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
		targetObject.gameObject.transform.localScale = new Vector3(targetObject.gameObject.transform.localScale.x + beBlock.BeInputs.numberValues[0], targetObject.gameObject.transform.localScale.y + beBlock.BeInputs.numberValues[0], targetObject.gameObject.transform.localScale.z + beBlock.BeInputs.numberValues[0]);

		BeController.PlayNextOutside(beBlock);
	}

	
}
