using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PianoInputs : MonoBehaviour, IPointerClickHandler
{
    public InputField pianoInputs;
    public GameObject piano;
    public AudioSource pianoAudioSource;
    public AudioClip[] pianoClips;
    public List<Button> keys;

    // Start is called before the first frame update
    void Start()
    {
        PlayKey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayKey()
    {
        foreach (var k in keys)
        {
            k.onClick.AddListener(delegate
            {
                pianoInputs.text = keys.IndexOf(k).ToString();
                pianoAudioSource.clip = pianoClips[keys.IndexOf(k)];
                pianoAudioSource.Play();
                if(piano.activeSelf)
                    piano.SetActive(false);
            });

        }
    }

    public void PlayKey(int index)
    {
        if(index < keys.Count)
        {
            pianoAudioSource.clip = pianoClips[index];
            pianoAudioSource.Play();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        piano.gameObject.SetActive(true);
    }
}
