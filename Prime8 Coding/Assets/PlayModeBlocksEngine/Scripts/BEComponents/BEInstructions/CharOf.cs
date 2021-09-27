using UnityEngine;
using System.Collections;

public class CharOf : BEInstruction
{
	string result;
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string output = beBlock.BeInputs.stringValues[1];

        try
        {
			char value = output[(int)(beBlock.BeInputs.numberValues[0] - 1)];
			result = value.ToString();
			//FindObjectOfType<GameManager>().resultVal.text = result;
		}
        catch (System.Exception e)
        {

            Debug.Log(e);
        }

		


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
