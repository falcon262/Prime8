using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Frames")]
    public GameObject ScriptFrame;
    public GameObject CostumeFrame;
    public GameObject SoundsFrame;

    [Header("Libraries")]
    public GameObject CharacterLibrary;
    public GameObject BackgroundLibrary;

    [Header("Block Toggles")]
    public GameObject Motion;
    public GameObject Looks;
    public GameObject Sound;
    public GameObject Pen;
    public GameObject Data;
    public GameObject Events;
    public GameObject Control;
    public GameObject Sensing;
    public GameObject Operators;
    public GameObject MoreBlocks;

    [Header("Block Types")]
    public GameObject MotionBlocks;
    public GameObject LooksBlocks;
    public GameObject SoundBlocks;
    public GameObject PenBlocks;
    public GameObject DataBlocks;
    public GameObject EventsBlocks;
    public GameObject ControlBlocks;
    public GameObject OperatorsBlocks;
    public GameObject SensingBlocks;
    public GameObject CustomBlocks;

    [Header("Background Elements")]
    public RectTransform background;
    public TextMeshProUGUI xCordinate;
    public TextMeshProUGUI xCordinateEnv;
    public TextMeshProUGUI yCordinate;
    public TextMeshProUGUI yCordinateEnv;
    Vector2 setPos;

    private void Start()
    {
        Debug.Log(background.sizeDelta);
        Debug.Log(background.rect.size);
        Debug.Log(background.rect);
        Debug.Log(background.rect.width);
        Debug.Log(background.rect.height);
        Debug.Log(background.rect.center);
        Debug.Log(background.rect.yMax);
        Debug.Log(background.rect.yMin);
        Debug.Log(background.rect.xMax);
        Debug.Log(background.rect.xMin);
        MoreBlocks.SetActive(true);
        LooksBlocks.SetActive(false);
        SoundBlocks.SetActive(false);
        PenBlocks.SetActive(false);
        DataBlocks.SetActive(false);
        EventsBlocks.SetActive(false);
        ControlBlocks.SetActive(false);
        OperatorsBlocks.SetActive(false);
        SensingBlocks.SetActive(false);
        CustomBlocks.SetActive(false);
    }

    private void Update()
    {
        VectorLogic();
        TypeSwitch();
    }

    void VectorLogic()
    {
        setPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, (Input.mousePosition.y), Camera.main.nearClipPlane));
        xCordinate.text = ((int)setPos.x).ToString();
        yCordinate.text = ((int)setPos.y).ToString();
        xCordinateEnv.text = ((int)setPos.x).ToString();
        yCordinateEnv.text = ((int)setPos.y).ToString();
    }

    #region HeaderSwitches
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
    #endregion

    #region LibrarySwitches
    public void CharacterLibraryOn()
    {
        CharacterLibrary.SetActive(true);
    }
    public void CharacterLibraryOff()
    {
        CharacterLibrary.SetActive(false);
    }
    public void BackgroundLibraryOn()
    {
        BackgroundLibrary.SetActive(true);
    }
    public void BackgroundLibraryff()
    {
        BackgroundLibrary.SetActive(false);
    }
    #endregion

    #region BlockTypeSwitching
    //Func to switch between block types
    public void TypeSwitch()
    {
        if (Motion.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(true);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Looks.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(true);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Sound.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(true);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Data.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(true);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Events.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(true);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Control.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(true);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Operators.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(true);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
        else if (Sensing.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(true);
            CustomBlocks.SetActive(false);
        }
        else if (MoreBlocks.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(false);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(true);
        }
        else if (Pen.GetComponent<LeanToggle>().On)
        {
            MotionBlocks.SetActive(false);
            LooksBlocks.SetActive(false);
            SoundBlocks.SetActive(false);
            PenBlocks.SetActive(true);
            DataBlocks.SetActive(false);
            EventsBlocks.SetActive(false);
            ControlBlocks.SetActive(false);
            OperatorsBlocks.SetActive(false);
            SensingBlocks.SetActive(false);
            CustomBlocks.SetActive(false);
        }
    }
    #endregion




}
