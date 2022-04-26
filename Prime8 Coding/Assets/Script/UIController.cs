using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Lean.Gui;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Frames")]
    public GameObject ScriptFrame;
    public GameObject CostumeFrame;
    public GameObject SoundsFrame;

    [Header("Libraries")]
    public GameObject CharacterCostumeLibrary;
    public GameObject SoundsLibrary;

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

    [Header("Data Elements")]
    public GameObject set;
    public GameObject add;
    public GameObject show;
    public GameObject hide;

    [Header("Background Elements")]
    public TextMeshProUGUI xCordinate;
    public TextMeshProUGUI xCordinateEnv;
    public TextMeshProUGUI yCordinate;
    public TextMeshProUGUI yCordinateEnv;
    Vector2 setPos;

    public SpriteRenderer character;

    public Image cordinateImage;
    public SaveLoadCode saveLoad;
    public GameObject speechBubble;
    public TextMeshProUGUI speech;
    public GameObject thinkBubble;
    public TextMeshProUGUI think;

    [Header("Library Elements")]
    [SerializeField] LeanToggle[] costumes;

    [Header("Costume Elements")]
    public List<GameObject> newCostume;
    [SerializeField] GameObject costumePrefab;
    [SerializeField] GameObject parentPlaceholder;
    public Image transparentCharacter;
    public GameManager gameManager;

    [Header("Sound")]
    public Button Mic;
    public bool canRecord;

    bool isClicked;
    string path;


    private void OnEnable()
    {
        //currentBackground.sprite = background.transform.gameObject.GetComponent<Image>().sprite;
        //currentCharacter.sprite = character.sprite;
        //transparentCharacter.sprite = character.sprite;
        newCostume = new List<GameObject>();

        gameManager = FindObjectOfType<GameManager>();

        xCordinate = gameManager.xCordinate;
        yCordinate = gameManager.yCordinate;

        if (gameManager.isNewtarget)
        {
            foreach (LeanToggle character in gameManager.characterSet)
            {
                if (character.On)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = character.transform.gameObject.GetComponentInChildren<Image>().sprite;
                }
            }

            if (gameManager.characters.Count == 0)
            {
                gameManager.characters.Add(Instantiate(gameManager.currentCharacter, gameManager.characterParentPos.transform.position, gameManager.characterParentPos.transform.rotation));
                gameManager.characters[0].transform.SetParent(gameManager.characterParentPos.transform);
                gameManager.characters[0].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                gameManager.characters[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(51.825f, -51.825f);
                gameManager.characters[0].GetComponent<LeanToggle>().TurnOn();
            }
            else if (gameManager.characters.Count != 0)
            {
                if (gameManager.characters.Count % 3 != 0)
                {
                    gameManager.characters.Add(Instantiate(gameManager.currentCharacter, gameManager.characterParentPos.transform.position, gameManager.characterParentPos.transform.rotation));
                    gameManager.characters[gameManager.characters.Count - 1].transform.SetParent(gameManager.characterParentPos.transform);
                    gameManager.characters[gameManager.characters.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    gameManager.characters[gameManager.characters.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(gameManager.characters[gameManager.characters.Count - 2].GetComponent<RectTransform>().anchoredPosition.x + 115, gameManager.characters[gameManager.characters.Count - 2].GetComponent<RectTransform>().anchoredPosition.y);
                    gameManager.characters[gameManager.characters.Count - 1].GetComponent<LeanToggle>().TurnOn();
                }
                else if (gameManager.characters.Count % 3 == 0)
                {

                    gameManager.characters.Add(Instantiate(gameManager.currentCharacter, gameManager.characterParentPos.transform.position, gameManager.characterParentPos.transform.rotation));
                    gameManager.characters[gameManager.characters.Count - 1].transform.SetParent(gameManager.characterParentPos.transform);
                    gameManager.characters[gameManager.characters.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    gameManager.characters[gameManager.characters.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(gameManager.characters[0].GetComponent<RectTransform>().anchoredPosition.x, gameManager.characters[gameManager.characters.Count - 3].GetComponent<RectTransform>().anchoredPosition.y - 115);
                    gameManager.characters[gameManager.characters.Count - 1].GetComponent<LeanToggle>().TurnOn();

                }

            }
            gameManager.isNewtarget = false;
        }

        if (gameManager.characters.Count == 0)
        {
            gameManager.characters.Add(Instantiate(gameManager.currentCharacter, gameManager.characterParentPos.transform.position, gameManager.characterParentPos.transform.rotation));
            gameManager.characters[0].transform.SetParent(gameManager.characterParentPos.transform);
            gameManager.characters[0].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            gameManager.characters[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(51.825f, -51.825f);
            gameManager.characters[0].GetComponent<LeanToggle>().TurnOn();
        }





        if (newCostume.Count == 0)
        {
            newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
            newCostume[0].transform.SetParent(parentPlaceholder.transform);
            newCostume[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newCostume[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
            newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite = character.sprite;

            foreach (LeanToggle item in costumes)
            {
                if (item.transform.gameObject.GetComponentInChildren<Image>().sprite.name == (character.sprite.name + "2"))
                {
                    newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                    newCostume[1].transform.SetParent(parentPlaceholder.transform);
                    newCostume[1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    newCostume[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, newCostume[0].GetComponent<RectTransform>().anchoredPosition.y - 100);
                    newCostume[1].transform.gameObject.GetComponentInChildren<Image>().sprite = item.transform.gameObject.GetComponentInChildren<Image>().sprite;
                }
            }
            foreach (Transform child in LooksBlocks.transform)
            {
                if (child.name == "SwitchCostumeTo")
                {
                    child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Clear();
                    child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                    child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[1].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                    //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                }
            }
            newCostume[0].GetComponent<LeanToggle>().TurnOn();
        }


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

    private void Start()
    {
        transparentCharacter.sprite = character.sprite;
        cordinateImage.sprite = character.sprite;

        Mic.onClick.AddListener(delegate
        {
            if (!canRecord)
            {
                canRecord = true;
            }
            else
            {
                canRecord = false;
            }
        });

        gameManager.saveCode.onClick.AddListener(delegate
        {
            saveLoad.OpenSaveDialog();
        });

        gameManager.loadCode.onClick.AddListener(delegate
        {
            saveLoad.OpenLoadDialog();
        });
        gameManager.saveCodeF.onClick.AddListener(delegate
        {
            saveLoad.OpenSaveDialog();
        });

        gameManager.loadCodeF.onClick.AddListener(delegate
        {
            saveLoad.OpenLoadDialog();
        });
        gameManager.clearCode.onClick.AddListener(delegate
        {
            saveLoad.BEClearCode();
        });
    }

    private void Update()
    {
        VectorLogic();
        TypeSwitch();

        DragCharacter();
    }

    void VectorLogic()
    {
        setPos = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameManager.background.transform.position.x) * 100, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - gameManager.background.transform.position.y) * 100);
        if (setPos.x > 240)
        {
            setPos.x = 240;
        }
        else if (setPos.x < -240)
        {
            setPos.x = -240;
        }
        if (setPos.y > 180)
        {
            setPos.y = 180;
        }
        else if (setPos.y < -180)
        {
            setPos.y = -180;
        }
        xCordinate.text = ((int)setPos.x).ToString();
        yCordinate.text = ((int)setPos.y).ToString();
        xCordinateEnv.text = ((int)character.gameObject.transform.localPosition.x).ToString();
        yCordinateEnv.text = ((int)character.gameObject.transform.localPosition.y).ToString();
    }

    void DragCharacter()
    {
        try
        {
            if (Input.GetMouseButton(0))
            {
                isClicked = true;
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
                if (hit.collider.tag == "Player" && isClicked)
                {

                    gameManager.characters[gameManager.targetObjects.IndexOf(hit.transform.gameObject)].transform.gameObject.GetComponent<LeanToggle>().TurnOn();
                    hit.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

    public void OnNewCostumeSelect()
    {
        foreach (LeanToggle costume in costumes)
        {
            if (costume.On)
            {
                CharacterCostumeLibraryOff();
                if (newCostume.Count == 0)
                {
                    newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                    newCostume[0].transform.SetParent(parentPlaceholder.transform);
                    newCostume[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    newCostume[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
                    newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite = costume.transform.gameObject.GetComponentInChildren<Image>().sprite;
                    newCostume[0].GetComponent<LeanToggle>().TurnOn();
                    foreach (Transform child in LooksBlocks.transform)
                    {
                        if (child.name == "SwitchCostumeTo")
                        {
                            child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Clear();
                            child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                            //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                        }
                    }
                }
                else if (newCostume.Count != 0)
                {
                    newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                    newCostume[newCostume.Count - 1].transform.SetParent(parentPlaceholder.transform);
                    newCostume[newCostume.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    newCostume[newCostume.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, newCostume[newCostume.Count - 2].GetComponent<RectTransform>().anchoredPosition.y - 100);
                    newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite = costume.transform.gameObject.GetComponentInChildren<Image>().sprite;
                    newCostume[newCostume.Count - 1].GetComponent<LeanToggle>().TurnOn();
                    foreach (Transform child in LooksBlocks.transform)
                    {
                        if (child.name == "SwitchCostumeTo")
                        {
                            child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                            //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                        }
                    }
                }
            }
        }
    }

    public void OpenCharacterExplorer()
    {
#if UNITY_EDITOR
        path = EditorUtility.OpenFilePanel("Upload new costume", "", "png");
#endif
        GetImage();
    }

    void GetImage()
    {
        if (!String.IsNullOrEmpty(path))
        {
            WWW www = new WWW("file:///" + path);

            if (newCostume.Count == 0)
            {
                newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                newCostume[0].transform.SetParent(parentPlaceholder.transform);
                newCostume[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                newCostume[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
                newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
                newCostume[0].GetComponent<LeanToggle>().TurnOn();
                foreach (Transform child in LooksBlocks.transform)
                {
                    if (child.name == "SwitchCostumeTo")
                    {
                        child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Clear();
                        child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                        //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                    }
                }
            }
            else if (newCostume.Count != 0)
            {
                newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                newCostume[newCostume.Count - 1].transform.SetParent(parentPlaceholder.transform);
                newCostume[newCostume.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                newCostume[newCostume.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, newCostume[newCostume.Count - 2].GetComponent<RectTransform>().anchoredPosition.y - 100);
                newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
                newCostume[newCostume.Count - 1].GetComponent<LeanToggle>().TurnOn();
                foreach (Transform child in LooksBlocks.transform)
                {
                    if (child.name == "SwitchCostumeTo")
                    {
                        child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                        //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                    }
                }
            }
        }
    }

    public void CreateEmptyCostume()
    {
        Texture2D empty;
        empty = new Texture2D(500, 299);
        if (newCostume.Count == 0)
        {
            newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
            newCostume[0].transform.SetParent(parentPlaceholder.transform);
            newCostume[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newCostume[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
            newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite = Sprite.Create(empty, new Rect(0, 0, empty.width, empty.height), new Vector2(0.5f, 0.5f));
            newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite.name = "empty";
            newCostume[0].GetComponent<LeanToggle>().TurnOn();
            foreach (Transform child in LooksBlocks.transform)
            {
                if (child.name == "SwitchCostumeTo")
                {
                    child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Clear();
                    child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[0].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                    //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                }
            }
        }
        else if (newCostume.Count != 0)
        {
            newCostume.Add(Instantiate(costumePrefab, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
            newCostume[newCostume.Count - 1].transform.SetParent(parentPlaceholder.transform);
            newCostume[newCostume.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newCostume[newCostume.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, newCostume[newCostume.Count - 2].GetComponent<RectTransform>().anchoredPosition.y - 100);
            newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite = Sprite.Create(empty, new Rect(0, 0, empty.width, empty.height), new Vector2(0.5f, 0.5f));
            newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite.name = "empty";
            newCostume[newCostume.Count - 1].GetComponent<LeanToggle>().TurnOn();
            foreach (Transform child in LooksBlocks.transform)
            {
                if (child.name == "SwitchCostumeTo")
                {
                    child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData() { text = newCostume[newCostume.Count - 1].transform.gameObject.GetComponentInChildren<Image>().sprite.name });
                    //Debug.Log(child.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Dropdown>().options[0].text);                      
                }
            }
        }
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

    public void CharacterCostumeLibraryOn()
    {
        CharacterCostumeLibrary.SetActive(true);
    }
    public void CharacterCostumeLibraryOff()
    {
        CharacterCostumeLibrary.SetActive(false);
    }
    public void SoundLibraryOn()
    {
        SoundsLibrary.SetActive(true);
    }
    public void SoundLibraryOff()
    {
        SoundsLibrary.SetActive(false);
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
