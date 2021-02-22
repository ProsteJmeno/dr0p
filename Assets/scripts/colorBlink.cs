using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBlink : MonoBehaviour
{
    public Color[] colors;
    private void Update()
    {
        if(PlayerPrefs.HasKey("colors") && PlayerPrefs.GetInt("colors") == 1)
        {

        }
    }
}
