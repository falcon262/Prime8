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
            FindObjectOfType<GameManager>().onEdge = false;
            FindObjectOfType<GameManager>().leftRight = false;
            FindObjectOfType<GameManager>().dontRotate = false;
            FindObjectOfType<GameManager>().allRound = false;
            BeController.PlayNextInside(beBlock);
        }
    }
}
