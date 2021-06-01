using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject ScriptFrame;
    public GameObject CostumeFrame;
    public GameObject SoundsFrame;
    public GameObject CharacterLibrary;
    public GameObject BackgroundLibrary;

    public void ScriptFrameOn()
    {
        ScriptFrame.SetActive(true);
    }
    public void ScirptFrameOff()
    {
        ScriptFrame.SetActive(false);
    }
    public void CostumeFrameOn()
    {
        CostumeFrame.SetActive(true);
    }
    public void CostumeFrameOff()
    {
        CostumeFrame.SetActive(false);
    }
    public void SoundFrameOn()
    {
        SoundsFrame.SetActive(true);
    }
    public void SoundFrameOff()
    {
        SoundsFrame.SetActive(false);
    }
    public void CharacterLibraryOn()
    {
        CharacterLibrary.SetActive(true);
    }
    public void CharacterLibraryOff()
    {
        CharacterLibrary.SetActive(false);
    }public void BackgroundLibraryOn()
    {
        BackgroundLibrary.SetActive(true);
    }
    public void BackgroundLibraryff()
    {
        BackgroundLibrary.SetActive(false);
    }

    
}
