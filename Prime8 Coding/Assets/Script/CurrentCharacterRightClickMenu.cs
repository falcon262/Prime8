using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCharacterRightClickMenu : MonoBehaviour
{
    public CurrentCharacter target;

    void Start()
    {

    }

    void Update()
    {
/*        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
            {
                gameObject.SetActive(false);
            }
        }*/
    }

    public void Duplicate()
    {
        gameObject.SetActive(false);
    }

    public void Delete()
    {
        //target.OnCharacterDelete();
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
