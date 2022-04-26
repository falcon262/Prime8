using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class SamplePlugin : MonoBehaviour, IPointerDownHandler
{

    [DllImport("__Internal")] private static extern void AddClickListenerForFileDialog();
    [DllImport("__Internal")] private static extern void FocusFileUploader();

    // Start is called before the first frame update
    void Start()
    {
        //AddClickListenerForFileDialog();
    }

    public void FileDialogResult(string fileUrl)
    {
        Debug.Log(fileUrl);
        StartCoroutine(LoadBlob(fileUrl));
    }

    IEnumerator LoadBlob(string url)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                FindObjectOfType<SoundController>().LocalSoundSelect(DownloadHandlerAudioClip.GetContent(www));
            }

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        FocusFileUploader();
    }
}