using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FunctionGoTo : BEInstruction
{
    
    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        GameManager manager = FindObjectOfType<GameManager>();

        targetObject.transform.localPosition = new Vector3(beBlock.BeInputs.numberValues[0], beBlock.BeInputs.numberValues[1],
            beBlock.BeInputs.numberValues[2]);
        if (manager.isPenDown)
        {
            Vector3[] positions = { Vector3.zero, -targetObject.transform.localPosition / 100 };
            GameObject line = Instantiate(manager.line, targetObject.transform.position, targetObject.transform.rotation);
            line.GetComponent<LineRenderer>().SetPositions(positions);
            //targetObject.GetComponent<LineRenderer>().SetPositions(positions);
        }

        BeController.PlayNextOutside(beBlock);
    }
}
