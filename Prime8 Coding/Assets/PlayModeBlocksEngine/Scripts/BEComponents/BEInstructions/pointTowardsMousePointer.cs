using UnityEngine;
using System.Collections;

public class pointTowardsMousePointer : BEInstruction
{ 	
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{

		float AngleRad = Mathf.Atan2(Input.mousePosition.y - targetObject.transform.position.y, Input.mousePosition.x - targetObject.transform.position.x);
		float AngleDeg = (180 / Mathf.PI) *AngleRad;
		targetObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

		BeController.PlayNextOutside(beBlock);
	}
 
}
