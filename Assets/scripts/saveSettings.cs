using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveSettings : MonoBehaviour
{
    float volume;
    int fullscreen;

    public void volumeChange(float changedVolume)
    {
        volume = changedVolume;
    }

    public void fullscreenChange(bool isFullscreen)
    {
        if(isFullscreen == true)
        {
            fullscreen = 1;
        }
        else
        {
            fullscreen = 0;
        }
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetInt("fullscreen", fullscreen);
        PlayerPrefs.Save();
    }
}
