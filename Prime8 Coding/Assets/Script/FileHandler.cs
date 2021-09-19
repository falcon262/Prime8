using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FileHandler : MonoBehaviour
{

    public Button save;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void New()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void SaveCode()
    {
        gameObject.SetActive(false);
    }

    public void LoadCode()
    { 
        gameObject.SetActive(false);
    }
}
