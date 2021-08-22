using UnityEngine;
using System.Collections;

public class changeYby : BEInstruction
{

	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y + beBlock.BeInputs.numberValues[0]);
		BeController.PlayNextOutside(beBlock);
	}
 
}
