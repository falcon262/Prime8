using UnityEngine;
using System.Collections;

public class setXto : BEInstruction
{

	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		targetObject.transform.localPosition = new Vector3(beBlock.BeInputs.numberValues[0], targetObject.transform.localPosition.y);

		BeController.PlayNextOutside(beBlock);
	}
 
}
