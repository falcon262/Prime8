using UnityEngine;
using System.Collections;

public class SetSizeTo : BEInstruction
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
		if (beBlock.BeInputs.numberValues[0] >= 0 && beBlock.BeInputs.numberValues[0] <= 100)
		{
			float size = (beBlock.BeInputs.numberValues[0] / 100) * 108.0343f;

			targetObject.gameObject.transform.localScale = new Vector3(size, size, size);
		}
		BeController.PlayNextOutside(beBlock);
	}
 
}
