using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Gui;

public class Sound : MonoBehaviour
{
    GameManager gameManager;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnChangeSound()
    {
        foreach (GameObject target in gameManager.targetObjects)
        {
            if (target.GetComponent<BETargetObject>().enabled == true)
            {
                target.GetComponent<SoundController>().GetWaveform(this.transform.gameObject.GetComponentInChildren<AudioSource>().clip);
                target.GetComponent<SoundController>().soundName.text = this.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            }
        }
    }

    public void DeleteSound()
    {
        foreach (GameObject target in gameManager.targetObjects)
        {
            if (target.GetComponent<BETargetObject>().enabled == true)
            {
                if (target.GetComponent<SoundController>().soundDeck.Count > 1)
                {
                    int currentIndex = target.GetComponent<SoundController>().soundDeck.IndexOf(this.transform.gameObject);
                    target.GetComponent<SoundController>().soundDeck[currentIndex - 1].GetComponent<LeanToggle>().TurnOn();
                    target.GetComponent<SoundController>().soundDeck.Remove(this.transform.gameObject);
                    Destroy(this.transform.gameObject);
                }
            }
        }
        
    }
}
