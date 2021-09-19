using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SayForSec : BEInstruction
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
		StartCoroutine(SpeechForTimeX(targetObject, beBlock.BeInputs.stringValues[0], beBlock.BeInputs.numberValues[1]));
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}

	IEnumerator SpeechForTimeX(BETargetObject targetObject, string speech,  float time)
    {
		targetObject.GetComponent<UIController>().speechBubble.SetActive(true);
		targetObject.GetComponent<UIController>().speech.text = speech;
		yield return new WaitForSeconds(time);
		targetObject.GetComponent<UIController>().speechBubble.SetActive(false);
	}
 
}
