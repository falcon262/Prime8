using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnVideoOnOffSimple : BEInstruction
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

		if (beBlock.BeInputs.stringValues[0] == "on")
		{
			targetObject.gameManager.webcaCamMotionDetection.gameObject.SetActive(true);
			targetObject.gameManager.webCam.gameObject.SetActive(true);
			targetObject.gameManager.background.GetComponent<Image>().color = new Color(1,1,1,0.5f);
			targetObject.gameManager.isCamOn = true;
		}
		else
		{
			targetObject.gameManager.webcaCamMotionDetection.gameObject.SetActive(false);
			targetObject.gameManager.webCam.gameObject.SetActive(false);
            targetObject.gameManager.background.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            targetObject.gameManager.isCamOn = false;
        }


		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
