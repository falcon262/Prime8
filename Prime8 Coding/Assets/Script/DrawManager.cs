using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;
    public GameManager gameManager;
    public GameObject drawings;
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
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
                        if (hit.collider.tag == "transparent" && isClicked)
                        {
                            isClicked = false;
                            Debug.Log("Something");
                            
                            
                            
                            /*var newPosition = target.transform.position; //arbitrary
                            var offset = newPosition - transform.position;
                            var trailRenderers = drawings.transform.gameObject.GetComponentsInChildren<TrailRenderer>();
                            foreach (var trailRenderer in trailRenderers)
                            {
                                GameObject costDrawing = Instantiate(trailRenderer.transform.gameObject,
                                    trailRenderer.transform.position, trailRenderer.transform.rotation);
                                
                                costDrawing.GetComponent<TrailRenderer>().time = trailRenderer.time;
                                costDrawing.GetComponent<TrailRenderer>().minVertexDistance = trailRenderer.minVertexDistance;
                                costDrawing.GetComponent<TrailRenderer>().widthMultiplier = trailRenderer.widthMultiplier;
                                costDrawing.GetComponent<TrailRenderer>().colorGradient = trailRenderer.colorGradient;
                                costDrawing.GetComponent<TrailRenderer>().numCornerVertices = trailRenderer.numCornerVertices;
                                
                                var positionCount = trailRenderer.positionCount;
                                for (var i = 0; i < positionCount; i++)
                                {
                                    trailRenderer.SetPosition(i, trailRenderer.GetPosition(i) + offset);
                                    trailRenderer.transform.SetParent(target.transform);
                                }
                            }
                            transform.position = newPosition;*/
                            
                        }
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
            if (/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || */Input.GetMouseButtonDown(0))
            {
                drawPrefab.transform.gameObject.GetComponent<TrailRenderer>().startColor =
                    parent.GetComponent<UIController>().selectedColor.color;
                drawPrefab.transform.gameObject.GetComponent<TrailRenderer>().endColor =
                    parent.GetComponent<UIController>().selectedColor.color;
                theTrail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);
                //characterTrail = (GameObject)Instantiate(drawPrefab, setPos, Quaternion.identity);
                theTrail.transform.SetParent(drawings.transform);
            }
            else if (/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved ||*/ Input.GetMouseButton(0))
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
