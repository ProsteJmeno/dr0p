using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject pauseMenu;
    public GameObject canvasContent;
    private void Start()
    {
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
    }

    public void volumeSlider(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void setFullscreen(bool isFulscreen)
    {
        Screen.fullScreen = isFulscreen;
    }

    public void backToMenu()
    {
        canvasContent.SetActive(true);
        gameObject.SetActive(false);
    }

    public void backToPauseMenu()
    {
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
