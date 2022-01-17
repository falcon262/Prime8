using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lean.Gui;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button restart;
    public Button saveCode;
    public Button saveCodeF;
    public Button loadCode;
    public Button loadCodeF;
    public Button clearCode;
    public Button shrink;
    public Button grow;

    public GameObject Var;
    public TextMeshProUGUI resultVal;
    public TextMeshProUGUI VarName;

    public bool clearVarOnce;

    public TextMeshProUGUI currentTitle;

    public GameObject line;

    public bool isPenDown;

    public bool onEdge;
    public bool leftRight;
    public bool dontRotate;
    public bool allRound;

    public GameObject CharacterLibrary;
    public GameObject BackgroundLibrary;

    public List<GameObject> targetObjects;
    public GameObject target;

    public List<GameObject> characters;
    public GameObject currentCharacter;
    public GameObject characterParentPos;

    public Button newBackgroundButton;
    public Button newCharacterButton;
    public Button onPlay;
    public Button onStop;

    public TextMeshProUGUI xCordinate;
    public TextMeshProUGUI yCordinate;

    public LeanToggle[] characterSet;
    public bool isNewtarget;

    [SerializeField] LeanToggle[] backgrounds;
    public GameObject background;
    public GameObject currentBackground;

    private void Start()
    {
        restart.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        newBackgroundButton.onClick.AddListener(delegate
        {
            BackgroundLibraryOn();
        });

        newCharacterButton.onClick.AddListener(delegate
        {
            CharacterLibraryOn();
        });


        targetObjects = new List<GameObject>();
        characters = new List<GameObject>();

        targetObjects.Add(Instantiate(target, target.transform.position, target.transform.rotation));
        
    }

    public void OnNewBackgroundSelect()
    {
        foreach (LeanToggle image in backgrounds)
        {
            if (image.On)
            {
                background.transform.gameObject.GetComponent<Image>().sprite = image.transform.gameObject.GetComponentInChildren<Image>().sprite;
                BackgroundLibrary.SetActive(false);
                currentBackground.transform.gameObject.GetComponent<Image>().sprite = background.transform.gameObject.GetComponent<Image>().sprite;
            }
        }
    }

    public void OnNewCharacterSelect()
    {
        isNewtarget = true;
        foreach (LeanToggle character in characterSet)
        {
            if (character.On)
            {
                CharacterLibraryOff();
                foreach (GameObject target in targetObjects)
                {
                    target.GetComponent<BETargetObject>().enabled = false;
                    //target.SetActive(false);
                }
                targetObjects.Add(Instantiate(target, target.transform.position, target.transform.rotation));


            }
        }
    }

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
}
