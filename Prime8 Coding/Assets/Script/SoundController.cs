using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Gui;
using UnityEngine.Networking;

public class SoundController : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] RawImage image;
    [SerializeField] LeanToggle[] sounds;
    [SerializeField] GameObject currentSound;
    [SerializeField] GameObject parentPlaceholder;
    [SerializeField] Button play;
    [SerializeField] Button stop;
    [SerializeField] Slider slider;
    public List<GameObject> soundDeck;
    public TMP_InputField soundName;
    [SerializeField] UIController controller;
    int width = 1024;
    int height = 260;
    bool playTime;
    Color[] blank;

    void Start()
    {
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
                    else if(!sound.GetComponentInChildren<AudioSource>().isPlaying)
                    {
                        playTime = false;
                        play.interactable = true;
                        slider.value = 0;
                    }   
                }
            }
        }
        
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

}
