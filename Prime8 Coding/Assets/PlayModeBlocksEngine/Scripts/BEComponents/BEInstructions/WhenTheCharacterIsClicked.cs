using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class WhenTheCharacterIsClicked : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
        try
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
                if (hit.collider.tag == "Player")
                {
                    beBlock.BeBlockGroup.isActive = true;
                    BeController.PlayNextInside(beBlock);
                }
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Does not have a collider");
            Debug.Log(e);
        }
       
    }
 
}
