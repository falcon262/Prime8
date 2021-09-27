using UnityEngine;
using System.Collections;

public class RandomPick : BEInstruction
{

	string result;
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{

		result = ((int)(Random.Range(beBlock.BeInputs.numberValues[0], beBlock.BeInputs.numberValues[1]))).ToString();
		//FindObjectOfType<GameManager>().resultVal.text = result;
		return result;
	}
	
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		// Use "beBlock.BeInputs" to get the input values
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
