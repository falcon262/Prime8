using UnityEngine;
using System.Collections;

public class setrotationstyle : BEInstruction
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
        if (targetObject.GetComponent<Collider2D>())
        {
            switch (beBlock.BeInputs.stringValues[0])
            {
                case "left-right":
                    FindObjectOfType<GameManager>().leftRight = true;
                    break;
                case "don't rotate":
                    FindObjectOfType<GameManager>().dontRotate = true;
                    break;
                case "all around":
                    FindObjectOfType<GameManager>().allRound = true;
                    break;
                default:
                    FindObjectOfType<GameManager>().leftRight = true;
                    break;
            }
        }
        BeController.PlayNextOutside(beBlock);
	}
 
}
