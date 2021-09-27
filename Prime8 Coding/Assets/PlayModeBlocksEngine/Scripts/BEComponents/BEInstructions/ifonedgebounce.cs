using UnityEngine;
using System.Collections;

public class ifonedgebounce : BEInstruction
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
		if (targetObject.transform.localPosition.x >= 240)
        {
			targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x - 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
		}
		else if (targetObject.transform.localPosition.x <= -240)
        {
			targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x + 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
		}

		if (targetObject.transform.localPosition.y >= 180)
        {
			targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y - 20, targetObject.transform.localPosition.z);
		}
		else if (targetObject.transform.localPosition.y <= -180)
        {
			targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y + 20, targetObject.transform.localPosition.z);
		}

		BeController.PlayNextOutside(beBlock);
	}
 
}
