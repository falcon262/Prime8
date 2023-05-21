using UnityEngine;
using System.Collections;
using System;

public class PlayNoteForBeats : BEInstruction
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
		// Use "beBlock.BeInputs" to get the input values
		Debug.Log(beBlock.transform.GetChild(0).transform.GetChild(1).transform.gameObject.name + "  " + beBlock.BeInputs.numberValues[0]);
		beBlock.transform.GetChild(0).transform.GetChild(1).transform.gameObject.GetComponent<PianoInputs>().PlayKey(Convert.ToInt32(beBlock.BeInputs.numberValues[0]));
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
