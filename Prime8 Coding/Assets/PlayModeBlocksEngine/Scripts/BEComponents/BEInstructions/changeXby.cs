using UnityEngine;
using System.Collections;

public class changeXby : BEInstruction
{
 
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x + beBlock.BeInputs.numberValues[0], targetObject.transform.localPosition.y);
		BeController.PlayNextOutside(beBlock);
	}
 
}
