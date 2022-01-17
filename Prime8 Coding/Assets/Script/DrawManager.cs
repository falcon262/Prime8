using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;
    public GameManager gameManager;
    GameObject theTrail;
    GameObject characterTrail;
    Plane planeObj;
    Vector3 startPos;
    Vector2 setPos;
    bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject target in gameManager.targetObjects)
        {
            if (target.GetComponent<BETargetObject>().enabled == true)
            {
                try
                {
                    if (Input.GetMouseButton(0))
                    {
                        isClicked = true;
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
                        if (hit.collider.tag == "transparent" && isClicked)
                        {

                            CharacterDraw(target, true);
                        }
                    }
                    else if (!Input.GetMouseButton(0))
                    {
                        isClicked = false;
                    }
                }
                catch (NullReferenceException e)
                {
                    //Not a target Object
                }
                
            }
        }
    }

    public void CharacterDraw(GameObject parent, bool canDraw)
    {
        //setPos = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameManager.background.transform.localPosition.x) * -2.265f, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - gameManager.background.transform.localPosition.y) * 0.13f);

        if (parent.GetComponent<UIController>().character.sprite.name == "empty" && canDraw)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {
                theTrail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);
                //characterTrail = (GameObject)Instantiate(drawPrefab, setPos, Quaternion.identity);
                theTrail.transform.SetParent(parent.transform);
                //characterTrail.transform.SetParent(parent.transform);
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float _dis;
                if (planeObj.Raycast(mouseRay, out _dis))
                {
                    theTrail.transform.position = mouseRay.GetPoint(_dis);
                }
            }
        }
    }
}
