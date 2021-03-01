using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveSettings : MonoBehaviour
{
    float volume;
    int colors;

    public void volumeChange(float changedVolume)
    {
        volume = changedVolume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void colorsChange(bool colorsSwitch)
    {
        if(colorsSwitch == true)
        {
            colors = 1;
        }
        else
        {
            colors = 0;
        }
        PlayerPrefs.SetInt("colors", colors);
    }

    public void OnApplicationQuit()
    {       
        PlayerPrefs.Save();
    }
}
