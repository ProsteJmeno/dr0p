using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadcolorsSettings : MonoBehaviour
{
    private void Awake()
    {
        bool colorSwitch = true;
        int colors = PlayerPrefs.GetInt("colors");
        if (colors == 1)
        {
            colorSwitch = true;
        }
        else
        {
            colorSwitch = false;
        }

        gameObject.GetComponent<Toggle>().isOn = colorSwitch;
    }
}
