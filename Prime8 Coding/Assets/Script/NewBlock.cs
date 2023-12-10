using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlock : MonoBehaviour
{
    public GameObject dialogue;

    public void OpenNewBlockDialogue()
    {
        dialogue.SetActive(true);
    }

    public void CloseNewBlockDialogue()
    {
        dialogue.SetActive(false);
    }
}
