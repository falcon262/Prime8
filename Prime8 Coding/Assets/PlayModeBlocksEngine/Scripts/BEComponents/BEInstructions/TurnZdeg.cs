using UnityEngine;
using System.Collections;

public class TurnZdeg : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		targetObject.transform.Rotate(-Vector3.forward, beBlock.BeInputs.numberValues[0]);

		BeController.PlayNextOutside(beBlock);
	}
 
}
