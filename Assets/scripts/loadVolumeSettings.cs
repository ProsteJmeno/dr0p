using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadVolumeSettings : MonoBehaviour
{
    private void Awake()
    {
        float volume = PlayerPrefs.GetFloat("volume");
        gameObject.GetComponent<Slider>().value = volume;
    }
}
