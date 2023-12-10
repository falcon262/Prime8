using UnityEngine;
using System.Collections;

public class glide : BEInstruction
{
    Vector3 initialPos;

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        GameManager manager = FindObjectOfType<GameManager>();

        initialPos = targetObject.transform.localPosition;
        Debug.Log(initialPos);
        StartCoroutine(Glide(beBlock.BeInputs.numberValues[0], beBlock.BeInputs.numberValues[1], beBlock.BeInputs.numberValues[2], targetObject));

        if (manager.isPenDown)
        {
            Vector3[] positions = { Vector3.zero, -targetObject.transform.localPosition / 100 };
            GameObject line = Instantiate(manager.line, targetObject.transform.position, targetObject.transform.rotation);
            line.GetComponent<LineRenderer>().SetPositions(positions);
        }

    }

    IEnumerator Glide(float slideTime, float xPos, float yPos, BETargetObject targetObject)
    {
        float elapsedTime = 0f;

        while(elapsedTime < slideTime)
        {
            float t = elapsedTime / slideTime;
            targetObject.transform.localPosition = Vector3.Lerp(initialPos, new Vector3(xPos, yPos), t);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        targetObject.transform.localPosition = new Vector3(xPos, yPos);

    }

}
