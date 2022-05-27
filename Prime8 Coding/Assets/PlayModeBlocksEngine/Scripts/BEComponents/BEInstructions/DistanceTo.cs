using UnityEngine;
using System.Collections;

public class DistanceTo : BEInstruction
{
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		
		 if (targetObject.GetComponent<Collider2D>())
        {
            switch (beBlock.BeInputs.stringValues[0])
            {
                case "mouse-pointer":
                    GameManager manager = FindObjectOfType<GameManager>();
					float dist;
					dist = Vector2.Distance(targetObject.transform.localPosition, new Vector2((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - manager.background.transform.position.x) * 100, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - manager.background.transform.position.y) * 100));
                    result = dist.ToString();
					Debug.Log(result);            
                    break;
                default:
                    targetObject.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
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
