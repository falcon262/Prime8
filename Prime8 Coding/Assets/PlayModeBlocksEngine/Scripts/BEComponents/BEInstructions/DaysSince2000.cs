using System;
using UnityEngine;
using System.Collections;

public class DaysSince2000 : BEInstruction
{
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		DateTime date;
		DateTime currentDate;
		if (targetObject.GetComponent<Collider2D>())
		{
			date = new DateTime(2000, 1,1);
			currentDate = DateTime.Now;
			result = currentDate.Subtract(date).TotalDays.ToString();
		}
		
		// Use "beBlock.BeInputs" to get the input values
		Debug.Log(result);
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
