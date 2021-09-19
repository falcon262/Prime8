using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Lean.Gui;

public class CurrentCharacter : MonoBehaviour, IPointerClickHandler
{
    UIController controller;
    GameManager gameManager;
    public CurrentCharacterRightClickMenu rightClickMenu;
    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnCharacterSelect()
    {
        StartCoroutine(CharacterSelect());
    }

    IEnumerator CharacterSelect()
    {
        if (this.transform.gameObject.GetComponent<LeanToggle>().On)
        {
            yield return new WaitForSeconds(0.1f);
            foreach (GameObject target in gameManager.targetObjects)
            {
                target.GetComponent<BETargetObject>().enabled = false;
                //target.SetActive(false);
            }
            gameManager.targetObjects[gameManager.characters.IndexOf(this.gameObject)].GetComponent<BETargetObject>().enabled = true;
            //gameManager.targetObjects[gameManager.characters.IndexOf(this.gameObject)].SetActive(true);
        }
    }

    public void OnCharacterDelete()
    {
        foreach (GameObject target in gameManager.targetObjects)
        {
            if (target.GetComponent<BETargetObject>().enabled == true)
            {
                if (target.GetComponent<UIController>().gameManager.characters.Count > 1)
                {
                    foreach (GameObject targetO in gameManager.targetObjects)
                    {
                        //targetO.GetComponent<BETargetObject>().enabled = false;
                        targetO.SetActive(false);
                    }
                    gameManager.targetObjects[gameManager.characters.IndexOf(this.gameObject)-1].SetActive(true);
                    int currentIndex = target.GetComponent<UIController>().gameManager.characters.IndexOf(this.transform.gameObject);
                    target.GetComponent<UIController>().gameManager.characters[currentIndex - 1].GetComponent<LeanToggle>().TurnOn();
                    target.GetComponent<UIController>().gameManager.characters.Remove(this.transform.gameObject);
                    
                    Destroy(this.transform.gameObject);
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClickMenu.target = this;
            rightClickMenu.transform.gameObject.SetActive(true);
        }
    }

    public void OpenRightClickMenu(Vector3 position)
    {
        rightClickMenu.transform.localPosition = position;
        rightClickMenu.target = this;
        rightClickMenu.gameObject.SetActive(true);
    }
}
