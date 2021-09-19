using UnityEngine;
using System.Collections;

public class GreaterThan : BEInstruction
{
    string result;

    public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
    {
        if (beBlock.BeInputs.isString)
        {
            if (beBlock.BeInputs.stringValues[0].Length > beBlock.BeInputs.stringValues[1].Length)
            {
                result = "1";
            }
            else
            {
                result = "0";
            }
        }
        else
        {
            if (beBlock.BeInputs.numberValues[0] > beBlock.BeInputs.numberValues[1])
            {
                result = "1";
            }
            else
            {
                result = "0";
            }
        }
        FindObjectOfType<GameManager>().resultVal.text = result;
        return result;
    }
}
