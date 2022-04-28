using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Gui;
using UnityEngine.Networking;
using System.Linq;
using FrostweepGames.Plugins.Native;

public class SoundController : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] RawImage image;
    [SerializeField] LeanToggle[] sounds;
    [SerializeField] GameObject currentSound;
    [SerializeField] GameObject parentPlaceholder;
    [SerializeField] Button play;
    [SerializeField] Button record;
    [SerializeField] Button stop;
    [SerializeField] Slider slider;
    public List<GameObject> soundDeck;
    public TMP_InputField soundName;
    [SerializeField] UIController controller;
    int width = 1024;
    int height = 260;
    bool playTime;

    bool isRecording;


    AudioClip _workingClip;

    Color[] blank;

    //Mic Settings
    public List<AudioClip> recordedClips;

    public int frequency = 44100;

    public int recordingTime = 120;

    public string selectedDevice;

    public bool makeCopy = false;

    public float averageVoiceLevel = 0f;

    public double voiceDetectionTreshold = 0.02d;

    public bool voiceDetectionEnabled = false;

    void Start()
    {
        RefreshMicrophoneDevicesButtonOnclickHandler();
        RequestPermission();

        soundDeck = new List<GameObject>();
        texture = new Texture2D(width, height);
        image.texture = texture;

        foreach (LeanToggle sound in sounds)
        {
            sound.OnOn.AddListener(delegate
            {
                sound.transform.gameObject.GetComponentInChildren<AudioSource>().Play();
            });
        }

        foreach (LeanToggle sound in sounds)
        {
            sound.OnOff.AddListener(delegate
            {
                sound.transform.gameObject.GetComponentInChildren<AudioSource>().Stop();
            });
        }

        if (soundDeck.Count == 0)
        {
            soundDeck.Add(Instantiate(currentSound, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
            soundDeck[0].transform.SetParent(parentPlaceholder.transform);
            soundDeck[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            soundDeck[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
            soundDeck[0].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = sounds[0].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            soundDeck[0].transform.gameObject.GetComponentInChildren<AudioSource>().clip = sounds[0].transform.GetComponentInChildren<AudioSource>().clip;
            GetWaveform(soundDeck[0].transform.GetComponentInChildren<AudioSource>().clip);
            soundDeck[0].GetComponent<LeanToggle>().TurnOn();
            soundName.text = soundDeck[0].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        }

        play.onClick.AddListener(delegate
        {
            if (soundDeck.Count != 0)
            {
                foreach (GameObject sound in soundDeck)
                {
                    if (sound.GetComponent<LeanToggle>().On)
                    {

                        sound.GetComponentInChildren<AudioSource>().Play();
                        play.interactable = false;
                        playTime = true;
                    }
                }
            }


        });

        stop.onClick.AddListener(delegate
        {

            if (soundDeck.Count != 0)
            {
                foreach (GameObject sound in soundDeck)
                {
                    if (sound.GetComponent<LeanToggle>().On)
                    {
                        sound.GetComponentInChildren<AudioSource>().Stop();
                        playTime = false;
                        play.interactable = true;
                        slider.value = 0;
                    }
                }
            }

        });

        controller.Mic.onClick.AddListener(RefreshMicrophoneDevicesButtonOnclickHandler);

        record.onClick.AddListener(delegate
        {
            if (!isRecording && controller.canRecord)
            {
                isRecording = true;
                record.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Recording...";
                record.transform.GetChild(0).transform.gameObject.GetComponent<Image>().color = Color.red;
                StartRecord();

            }
            else if (isRecording && controller.canRecord)
            {
                isRecording = false;
                record.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Click to record sound";
                record.transform.GetChild(0).transform.gameObject.GetComponent<Image>().color = Color.black;
                StopRecord();
            }
        });



    }


    void Update()
    {
        if (playTime)
        {
            foreach (GameObject sound in soundDeck)
            {
                if (sound.GetComponent<LeanToggle>().On)
                {
                    if (sound.GetComponentInChildren<AudioSource>().isPlaying)
                    {
                        slider.value += sound.GetComponentInChildren<AudioSource>().time / sound.GetComponentInChildren<AudioSource>().clip.length * 1 * Time.deltaTime;
                    }
                    else if (!sound.GetComponentInChildren<AudioSource>().isPlaying)
                    {
                        playTime = false;
                        play.interactable = true;
                        slider.value = 0;
                    }
                }
            }
        }

        if (controller.canRecord)
            record.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(true);
        else
            record.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(false);

    }

    public void GetWaveform(AudioClip clip)
    {
        blank = new Color[texture.width * texture.height];
        var size = clip.samples * clip.channels;
        var samples = new float[size];
        clip.GetData(samples, 0);
        // clear the texture
        texture.SetPixels(blank, 0);
        // draw the waveform
        for (int i = 0; i < size; i++)
        {
            texture.SetPixel(texture.width * i / size, (int)(texture.height * (samples[i] + 1f) / 2), Color.gray);
        }
        // upload to the graphics card
        texture.Apply();
    }

    public void SoundSelect()
    {
        foreach (LeanToggle sound in sounds)
        {
            if (sound.On)
            {
                controller.SoundLibraryOff();
                if (soundDeck.Count == 0)
                {
                    soundDeck.Add(Instantiate(currentSound, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                    soundDeck[0].transform.SetParent(parentPlaceholder.transform);
                    soundDeck[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    soundDeck[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
                    soundDeck[0].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = sound.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
                    GetWaveform(sound.transform.GetComponentInChildren<AudioSource>().clip);
                    soundDeck[soundDeck.Count - 1].transform.gameObject.GetComponentInChildren<AudioSource>().clip = sound.transform.GetComponentInChildren<AudioSource>().clip;
                    soundDeck[0].GetComponent<LeanToggle>().TurnOn();
                }
                else if (soundDeck.Count != 0)
                {
                    soundDeck.Add(Instantiate(currentSound, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
                    soundDeck[soundDeck.Count - 1].transform.SetParent(parentPlaceholder.transform);
                    soundDeck[soundDeck.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    soundDeck[soundDeck.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, soundDeck[soundDeck.Count - 2].GetComponent<RectTransform>().anchoredPosition.y - 100);
                    soundDeck[soundDeck.Count - 1].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = sound.transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
                    GetWaveform(sound.transform.GetComponentInChildren<AudioSource>().clip);
                    soundDeck[soundDeck.Count - 1].transform.gameObject.GetComponentInChildren<AudioSource>().clip = sound.transform.GetComponentInChildren<AudioSource>().clip;
                    soundDeck[soundDeck.Count - 1].GetComponent<LeanToggle>().TurnOn();
                }
            }
        }
    }

    public void LocalSoundSelect(AudioClip sound)
    {
        if (soundDeck.Count == 0)
        {
            soundDeck.Add(Instantiate(currentSound, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
            soundDeck[0].transform.SetParent(parentPlaceholder.transform);
            soundDeck[0].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            soundDeck[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60.27f);
            soundDeck[0].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "upload";
            GetWaveform(sound);
            soundDeck[soundDeck.Count - 1].transform.gameObject.GetComponentInChildren<AudioSource>().clip = sound;
            soundDeck[0].GetComponent<LeanToggle>().TurnOn();
        }
        else if (soundDeck.Count != 0)
        {
            soundDeck.Add(Instantiate(currentSound, parentPlaceholder.transform.position, parentPlaceholder.transform.rotation));
            soundDeck[soundDeck.Count - 1].transform.SetParent(parentPlaceholder.transform);
            soundDeck[soundDeck.Count - 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            soundDeck[soundDeck.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, soundDeck[soundDeck.Count - 2].GetComponent<RectTransform>().anchoredPosition.y - 100);
            soundDeck[soundDeck.Count - 1].transform.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "upload";
            GetWaveform(sound);
            soundDeck[soundDeck.Count - 1].transform.gameObject.GetComponentInChildren<AudioSource>().clip = sound;
            soundDeck[soundDeck.Count - 1].GetComponent<LeanToggle>().TurnOn();
        }
    }

    private void OnDestroy()
    {
        CustomMicrophone.RecordStreamDataEvent -= RecordStreamDataEventHandler;
        CustomMicrophone.PermissionStateChangedEvent -= PermissionStateChangedEventHandler;
        CustomMicrophone.RecordStartedEvent -= RecordStartedEventHandler;
        CustomMicrophone.RecordEndedEvent -= RecordEndedEventHandler;
    }

    /// <summary>
    /// Works only in WebGL
    /// </summary>
    /// <param name="samples"></param>
    private void RecordStreamDataEventHandler(float[] samples)
    {
        // handle streaming recording data
    }

    /// <summary>
    /// Works only in WebGL
    /// </summary>
    /// <param name="permissionGranted"></param>
    private void PermissionStateChangedEventHandler(bool permissionGranted)
    {
        // handle current permission status

        Debug.Log($"Permission state changed on: {permissionGranted}");
    }

    private void RecordEndedEventHandler()
    {
        // handle record ended event

        Debug.Log("Record ended");
    }

    private void RecordStartedEventHandler()
    {
        // handle record started event

        Debug.Log("Record started");
    }

    private void RefreshMicrophoneDevicesButtonOnclickHandler()
    {
        CustomMicrophone.RefreshMicrophoneDevices();

        if (!CustomMicrophone.HasConnectedMicrophoneDevices())
            return;

        Debug.Log("Refreshed");
        DevicesDropdownValueChangedHandler(0);
    }

    private void RequestPermission()
    {
        CustomMicrophone.RequestMicrophonePermission();
    }

    private void StartRecord()
    {
        if (!CustomMicrophone.HasConnectedMicrophoneDevices())
        {
            Debug.Log("No connected devices found. Refreshing...");
            CustomMicrophone.RefreshMicrophoneDevices();
            return;
        }

        _workingClip = CustomMicrophone.Start(selectedDevice, false, recordingTime, frequency);
    }

    private void StopRecord()
    {
        if (!CustomMicrophone.IsRecording(selectedDevice))
            return;

        // End recording is an async operation, so you have to provide callback or subscribe on RecordEndedEvent event
        CustomMicrophone.End(selectedDevice, () =>
        {
            if (makeCopy)
            {
                recordedClips.Add(CustomMicrophone.MakeCopy($"copy{recordedClips.Count}", recordingTime, frequency, _workingClip));
                LocalSoundSelect(recordedClips.Last());

            }
            else
            {
                LocalSoundSelect(_workingClip);
            }
        });
    }

    private void DevicesDropdownValueChangedHandler(int index)
    {
        if (index < CustomMicrophone.devices.Length)
        {
            selectedDevice = CustomMicrophone.devices[index];
        }
    }

}
