using UnityEngine;
using System.Collections;

public class setYyto : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, beBlock.BeInputs.numberValues[0]);
		BeController.PlayNextOutside(beBlock);
	}
 
}
