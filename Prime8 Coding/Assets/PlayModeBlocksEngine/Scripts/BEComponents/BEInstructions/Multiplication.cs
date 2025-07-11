using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class Multiplication : BEInstruction
{
    string result;

    public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
    {
        if (beBlock.BeInputs.isString)
        {
            result = "";
            if (beBlock.BeInputs.numberValues[0] != 0)
            {
                for (int i = 0; i < beBlock.BeInputs.numberValues[0]; i++)
                {
                    result += beBlock.BeInputs.stringValues[1];
                }
            }
            else if (beBlock.BeInputs.numberValues[1] != 0)
            {
                for (int i = 0; i < beBlock.BeInputs.numberValues[1]; i++)
                {
                    result += beBlock.BeInputs.stringValues[0];
                }
            }
            else
            {
                result = beBlock.BeInputs.stringValues[0];
            }
        }
        else
        {
            float tempResult = beBlock.BeInputs.numberValues[0] * beBlock.BeInputs.numberValues[1];
            result = tempResult.ToString(CultureInfo.InvariantCulture);
        }
        //FindObjectOfType<GameManager>().resultVal.text = result;
        return result;
    }
}
