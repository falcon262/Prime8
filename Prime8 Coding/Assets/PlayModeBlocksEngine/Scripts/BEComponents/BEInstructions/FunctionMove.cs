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

            if (manager.onEdge)
            {
                if (manager.leftRight)
                {
                    if (targetObject.transform.localPosition.x >= 225)
                    {
                        targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x - 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 180, 0);


                    }
                    else if (targetObject.transform.localPosition.x <= -225)
                    {
                        targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x + 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    }

                    if (targetObject.transform.localPosition.y >= 128)
                    {
                        targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y - 20, targetObject.transform.localPosition.z);
                    }
                    else if (targetObject.transform.localPosition.y <= -128)
                    {
                        targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y + 20, targetObject.transform.localPosition.z);
                    }
                }
                else if (manager.dontRotate)
                {
                    if (targetObject.transform.localPosition.x >= 225)
                    {
                        targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x - 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 180, 0);
                        targetObject.transform.gameObject.GetComponent<SpriteRenderer>().flipX = true;


                    }
                    else if (targetObject.transform.localPosition.x <= -225)
                    {
                        targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x + 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        targetObject.transform.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    }

                    if (targetObject.transform.localPosition.y >= 128)
                    {
                        targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y - 20, targetObject.transform.localPosition.z);
                    }
                    else if (targetObject.transform.localPosition.y <= -128)
                    {
                        targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y + 20, targetObject.transform.localPosition.z);
                    }
                }
                else if (manager.allRound)
                {
                    if (targetObject.transform.localPosition.x >= 225)
                    {
                        targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x - 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 0, 180);


                    }
                    else if (targetObject.transform.localPosition.x <= -225)
                    {
                        targetObject.transform.localPosition = new Vector3((targetObject.transform.localPosition.x + 20), targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    }

                    if (targetObject.transform.localPosition.y >= 128)
                    {
                        targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y - 20, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 0, -90);
                    }
                    else if (targetObject.transform.localPosition.y <= -128)
                    {
                        targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, targetObject.transform.localPosition.y + 20, targetObject.transform.localPosition.z);
                        targetObject.transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                }
            }

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
