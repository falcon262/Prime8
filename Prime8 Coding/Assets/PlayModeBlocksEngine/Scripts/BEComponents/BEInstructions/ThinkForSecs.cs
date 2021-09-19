using UnityEngine;
using System.Collections;

public class ThinkForSecs : BEInstruction
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
		StartCoroutine(ThinkForTimeX(targetObject, beBlock.BeInputs.stringValues[0], beBlock.BeInputs.numberValues[1]));
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}

	IEnumerator ThinkForTimeX(BETargetObject targetObject, string thought, float time)
	{
		targetObject.GetComponent<UIController>().thinkBubble.SetActive(true);
		targetObject.GetComponent<UIController>().think.text = thought;
		yield return new WaitForSeconds(time);
		targetObject.GetComponent<UIController>().thinkBubble.SetActive(false);
	}

}
