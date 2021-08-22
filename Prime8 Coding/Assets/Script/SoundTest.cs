using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] RawImage image;
    [SerializeField] AudioSource sound;
    int width = 1024;
    int height = 260;
    Color[] blank;
    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(width, height);
        image.texture = texture;
        
    }

    private void Update()
    {
        GetWaveform(sound.clip, sound);
    }

    public void GetWaveform(AudioClip clip, AudioSource source)
    {
        blank = new Color[texture.width * texture.height];
        var size = clip.samples * clip.channels;
        var samples = new float[size];
        source.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        //clip.GetData(samples, 0);
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
}
