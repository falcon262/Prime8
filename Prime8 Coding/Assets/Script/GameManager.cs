using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public float gameTimer;

    public GameObject Var;
    public GameObject answer;
    public GameObject askInput;
    public GameObject timer;
    public GameObject currentDateTime;
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

    [SerializeField] private LeanToggle[] backgrounds;
    public GameObject background;
    public GameObject currentBackground;

    public webCamMotionDetection webcaCamMotionDetection;

    public GameObject webCam;

    public bool isCamOn;


    private void Start()
    {
        restart.onClick.AddListener(delegate { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });

        newBackgroundButton.onClick.AddListener(delegate { BackgroundLibraryOn(); });

        newCharacterButton.onClick.AddListener(delegate { CharacterLibraryOn(); });


        targetObjects = new List<GameObject>();
        characters = new List<GameObject>();

        targetObjects.Add(Instantiate(target, target.transform.position, target.transform.rotation));
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;
        timer.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            gameTimer.ToString();
    }

    public void AcceptAskInput()
    {
        answer.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            askInput.GetComponentInChildren<TMP_InputField>().text;
        askInput.SetActive(false);
    }

    public void OnNewBackgroundSelect()
    {
        foreach (var image in backgrounds)
            if (image.On)
            {
                background.transform.gameObject.GetComponent<Image>().sprite =
                    image.transform.gameObject.GetComponentInChildren<Image>().sprite;
                BackgroundLibrary.SetActive(false);
                currentBackground.transform.gameObject.GetComponent<Image>().sprite =
                    background.transform.gameObject.GetComponent<Image>().sprite;
            }
    }

    public void OnNewCharacterSelect()
    {
        isNewtarget = true;
        foreach (var character in characterSet)
            if (character.On)
            {
                CharacterLibraryOff();
                foreach (var target in targetObjects)
                    target.GetComponent<BETargetObject>().enabled = false;
                //target.SetActive(false);
                targetObjects.Add(Instantiate(target, target.transform.position, target.transform.rotation));
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