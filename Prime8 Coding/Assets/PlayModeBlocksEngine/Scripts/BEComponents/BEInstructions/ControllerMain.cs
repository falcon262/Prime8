using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMain : BEInstruction
{
    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        if(beBlock.BeBlockGroup.isActive)
        {
            FindObjectOfType<GameManager>().isPenDown = false;
            BeController.PlayNextInside(beBlock);
        }
    }
}
