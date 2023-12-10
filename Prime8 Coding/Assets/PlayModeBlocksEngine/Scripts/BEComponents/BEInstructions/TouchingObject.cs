using UnityEngine;
using System.Collections;

public class TouchingObject : BEInstruction
{

    // Use this for Operations
    public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
    {
        string result = "0";

        // Use "beBlock.BeInputs" to get the input values
        if (targetObject.GetComponent<Collider2D>())
        {
            switch (beBlock.BeInputs.stringValues[0])
            {
                case "mouse-pointer":
                    try
                    {
                        if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward).collider.tag == "Player")
                        {
                            result = "1";
                        }
                    }
                    catch (System.Exception ex)
                    {
                        // Hitting other than the player which is not an object
                    }
                    return result;
                case "edge":
                    if (targetObject.transform.gameObject.GetComponent<Collider2D>().IsTouching(FindObjectOfType<GameManager>().background.transform.gameObject.GetComponent<EdgeCollider2D>()))
                        result = "1";
                    return result;
                default:
                    return result;

            }
        }
        else
        {
            return result;
        }
    }

    // Use this for Functions
    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        // Use "beBlock.BeInputs" to get the input values

        // Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
        BeController.PlayNextOutside(beBlock);
    }

}
