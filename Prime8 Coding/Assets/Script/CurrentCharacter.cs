using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

public class CurrentCharacter : MonoBehaviour
{
    UIController controller;
    GameManager gameManager;

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
        if (controller.newCostume.Count > 1)
        {
            int currentIndex = controller.newCostume.IndexOf(this.transform.gameObject);
            controller.newCostume[currentIndex - 1].GetComponent<LeanToggle>().TurnOn();
            controller.newCostume.Remove(this.transform.gameObject);
            Destroy(this.transform.gameObject);
        }
    }
}
