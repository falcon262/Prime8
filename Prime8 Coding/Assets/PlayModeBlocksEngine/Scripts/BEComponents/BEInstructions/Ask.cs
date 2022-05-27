using UnityEngine;
using System.Collections;

public class Ask : BEInstruction
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
		
		StartCoroutine(AskAction(targetObject, beBlock));
		manager.askInput.SetActive(true);
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}

	IEnumerator AskAction(BETargetObject targetObject, BEBlock beBlock)
	{
		targetObject.GetComponent<UIController>().speechBubble.SetActive(true);
		targetObject.GetComponent<UIController>().speech.text = beBlock.BeInputs.stringValues[0];
		yield return new WaitForSeconds(5);
		targetObject.GetComponent<UIController>().speechBubble.SetActive(false);
	}
 
}
