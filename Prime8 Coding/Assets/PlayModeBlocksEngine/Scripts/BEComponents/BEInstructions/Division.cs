using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Division : BEInstruction
{
    string result;

    public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
    {

        float tempResult = beBlock.BeInputs.numberValues[0] / beBlock.BeInputs.numberValues[1];
        result = tempResult.ToString(CultureInfo.InvariantCulture);
        //FindObjectOfType<GameManager>().resultVal.text = result;
        return result;
    }
}
