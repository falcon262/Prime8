using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FunctionMove : BEInstruction
{
    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        GameManager manager = FindObjectOfType<GameManager>();


        if (targetObject.GetComponent<Collider2D>())
        {
            targetObject.transform.localPosition += targetObject.transform.right * (beBlock.BeInputs.numberValues[0]);
            if (manager.isPenDown)
            {
                Vector3[] positions = { Vector3.zero, -(new Vector3((beBlock.BeInputs.numberValues[0]), 0,0)/100) };
                GameObject line = Instantiate(manager.line, targetObject.transform.position, targetObject.transform.rotation);
                line.GetComponent<LineRenderer>().SetPositions(positions);
                //targetObject.GetComponent<LineRenderer>().SetPositions(positions);
            }
        }
        else if (targetObject.GetComponent<Collider>())
        {
            targetObject.transform.localPosition += targetObject.transform.forward * (beBlock.BeInputs.numberValues[0]);
        }

        BeController.PlayNextOutside(beBlock);
    }
}
