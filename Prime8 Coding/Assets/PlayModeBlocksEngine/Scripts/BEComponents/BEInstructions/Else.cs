using UnityEngine;
using System.Collections;

public class Else : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
        if (beBlock.beChildBlocksList.Count > 0)
        {
            BeController.PlayNextInside(beBlock);
        }
        else
        {
            BeController.PlayNextOutside(beBlock);
        }

    }
 
}
