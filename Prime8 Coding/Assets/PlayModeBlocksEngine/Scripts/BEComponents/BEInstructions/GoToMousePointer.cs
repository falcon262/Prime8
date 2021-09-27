using UnityEngine;
using System.Collections;

public class GoToMousePointer : BEInstruction
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
                case "mouse-pointer":
                    GameManager manager = FindObjectOfType<GameManager>();
                    targetObject.transform.localPosition = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - manager.background.transform.position.x) * 100, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - manager.background.transform.position.y) * 100);                    
                    break;
                case "random":
                    float randomXPos = Random.Range(-240f, 240f);
                    float randomYPos = Random.Range(-180f, 180f);
                    targetObject.transform.localPosition = new Vector3(randomXPos, randomYPos);
                    break;
                default:
                    targetObject.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
        }

        BeController.PlayNextOutside(beBlock);
    }
 
}
