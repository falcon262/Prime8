using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using System.Collections;
using System;

public class NextCostume : BEInstruction
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
		int i = 0;
        // Use "beBlock.BeInputs" to get the input values
        try
        {
            for (i = 0; i < targetObject.GetComponent<UIController>().newCostume.Count; i++)
            {
				if (targetObject.GetComponent<UIController>().newCostume[i].GetComponentInChildren<LeanToggle>().On)
				{
					if (targetObject.GetComponent<UIController>().newCostume[i].Equals(targetObject.GetComponent<UIController>().newCostume[targetObject.GetComponent<UIController>().newCostume.Count - 1]))
					{
						//Debug.Log("Yes they are equal");
						targetObject.GetComponent<UIController>().newCostume[0].GetComponent<LeanToggle>().TurnOn();
						break;
					}
                    else
                    {
						targetObject.GetComponent<UIController>().newCostume[i + 1].GetComponent<LeanToggle>().TurnOn();
						break;
					}
											
				}
			}
			/*Debug.Log(i);
			if (targetObject.GetComponent<UIController>().newCostume[i].Equals(targetObject.GetComponent<UIController>().newCostume[targetObject.GetComponent<UIController>().newCostume.Count - 1]))
			{
				Debug.Log("Yes they are equal");
				targetObject.GetComponent<UIController>().newCostume[0].GetComponent<LeanToggle>().TurnOn();
			}*/
		}
        catch (ArgumentOutOfRangeException e)
        {
			Debug.Log(e);
		}
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
