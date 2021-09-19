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
		GameManager manager = FindObjectOfType<GameManager>();
		targetObject.transform.localPosition = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - manager.background.transform.position.x) * 100, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - manager.background.transform.position.y) * 100);
		BeController.PlayNextOutside(beBlock);
	}
 
}
