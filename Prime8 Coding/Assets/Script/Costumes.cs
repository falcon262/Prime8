using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

public class Costumes : MonoBehaviour
{
    UIController controller;
    GameManager gameManager;

    private void OnEnable()
    {
        controller = FindObjectOfType<UIController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ChangeCostume()
    {
        foreach (GameObject character in gameManager.characters)
        {
            if (character.GetComponent<LeanToggle>().On)
            {
                character.transform.gameObject.GetComponentInChildren<Image>().sprite = this.transform.gameObject.GetComponentInChildren<Image>().sprite;
            }
        }
        foreach (GameObject target in gameManager.targetObjects)
        {
            if (target.GetComponent<BETargetObject>().enabled == true)
            {
                if(this.transform.gameObject.GetComponentInChildren<Image>().sprite.name != "empty")
                {
                    target.GetComponent<UIController>().character.sprite = this.transform.gameObject.GetComponentInChildren<Image>().sprite;
                    target.GetComponent<UIController>().transparentCharacter.transform.parent.transform.gameObject.SetActive(true);
                    target.GetComponent<UIController>().transparentCharacter.sprite = this.transform.gameObject.GetComponentInChildren<Image>().sprite;
                    target.GetComponent<UIController>().cordinateImage.sprite = this.transform.gameObject.GetComponentInChildren<Image>().sprite;
                }
                else
                {
                    target.GetComponent<UIController>().character.sprite = this.transform.gameObject.GetComponentInChildren<Image>().sprite;
                    target.GetComponent<UIController>().transparentCharacter.transform.parent.transform.gameObject.SetActive(false);
                    target.GetComponent<UIController>().cordinateImage.sprite = this.transform.gameObject.GetComponentInChildren<Image>().sprite;
                }
            }
        }
    }

    public void DeleteCostume()
    {
        foreach (GameObject target in gameManager.targetObjects)
        {
            if (target.GetComponent<BETargetObject>().enabled == true)
            {
                if (target.GetComponent<UIController>().newCostume.Count > 1)
                {
                    int currentIndex = target.GetComponent<UIController>().newCostume.IndexOf(this.transform.gameObject);
                    target.GetComponent<UIController>().newCostume[currentIndex - 1].GetComponent<LeanToggle>().TurnOn();
                    target.GetComponent<UIController>().newCostume.Remove(this.transform.gameObject);
                    Destroy(this.transform.gameObject);
                }
            }
        }
              
    }
}
