using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class CurrentDateTimer : BEInstruction
{
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		DateTime date;
		if (targetObject.GetComponent<Collider2D>())
        {
	        date = DateTime.Now;
            switch (beBlock.BeInputs.stringValues[0])
            {
                case "year":
	                result = date.Year.ToString();
	                break;
                case "month":
	                result = date.Month.ToString();
	                break;
                case "date":
	                result = date.Day.ToString();
	                break;
                case "day of week":
	                result = date.DayOfWeek.ToString();
	                break;
                case "hour":
	                result = date.Hour.ToString();
	                break;
                case "minute":
	                result = date.Minute.ToString();
	                break;
                case "second":
	                result = date.Second.ToString();
	                break;
                default:
                    targetObject.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
        }
		
		// Use "beBlock.BeInputs" to get the input values
		GameManager manager = FindObjectOfType<GameManager>();
		
		manager.currentDateTime.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "  " + beBlock.BeInputs.stringValues[0];
		manager.currentDateTime.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = result;
		Debug.Log((result));
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
