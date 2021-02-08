using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadFullscreenSettings : MonoBehaviour
{
    private void Awake()
    {
        bool isFullscreen = true;
        int fullscreen = PlayerPrefs.GetInt("fullscreen");
        if (fullscreen == 1)
        {
            isFullscreen = true;
        }
        else
        {
            isFullscreen = false;
        }

        gameObject.GetComponent<Toggle>().isOn = isFullscreen;
    }
}
