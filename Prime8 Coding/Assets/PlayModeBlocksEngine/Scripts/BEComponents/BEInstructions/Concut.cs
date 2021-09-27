using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Concut : BEInstruction
{
    string result;

    // Use this for Operations
    public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
        if (beBlock.BeInputs.isString)
        {
            result = beBlock.BeInputs.stringValues[0] + beBlock.BeInputs.stringValues[1];
        }
        else
        {
            result = beBlock.BeInputs.numberValues[0].ToString() + beBlock.BeInputs.numberValues[1].ToString();
            //result = tempResult.ToString(CultureInfo.InvariantCulture);
        }
        //FindObjectOfType<GameManager>().resultVal.text = result;
        return result;
    }
	
}
