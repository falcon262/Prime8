using UnityEngine;
using System.Collections;

public class WaitUntilValue : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
        if (beBlock.beBlockFirstPlay)
        {
            beBlock.beBlockFirstPlay = false;
        }
        if (beBlock.BeInputs.stringValues[0] == "1")
        {
            beBlock.beBlockFirstPlay = true;
            BeController.PlayNextOutside(beBlock);
        }
    }
 
}
