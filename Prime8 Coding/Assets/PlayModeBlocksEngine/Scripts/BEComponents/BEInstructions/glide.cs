using UnityEngine;
using System.Collections;

public class glide : BEInstruction
{

    int counterForRepetitions;
    float counterForMovement = 0;
    float movementDuration; //seconds
    Vector3 startPos;
    Vector3 direction;

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        movementDuration = beBlock.BeInputs.numberValues[0];
        if (beBlock.beBlockFirstPlay)
        {
            counterForRepetitions = 1;
            startPos = targetObject.transform.localPosition;
            beBlock.beBlockFirstPlay = false;
        }

        if (counterForMovement == 0)
        {
            startPos = targetObject.transform.localPosition;
        }

        if (counterForMovement <= movementDuration)
        {
            counterForMovement += Time.deltaTime;
            if (targetObject.GetComponent<Collider2D>())
            {
                direction = targetObject.transform.right;
            }
            else if (targetObject.GetComponent<Collider>())
            {
                direction = targetObject.transform.forward;
            }
            targetObject.transform.localPosition = Vector3.Lerp(startPos, new Vector3(beBlock.BeInputs.numberValues[1], beBlock.BeInputs.numberValues[2]), counterForMovement / movementDuration);
        }
        else
        {
            counterForMovement = 0;
            counterForRepetitions--;

            if (counterForRepetitions <= 0)
            {
                beBlock.beBlockFirstPlay = true;
                BeController.PlayNextOutside(beBlock);
            }
        }

    }

}
