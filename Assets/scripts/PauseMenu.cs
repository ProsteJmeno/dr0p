using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public Text highscore;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCheck();
        }
    }

    public void pauseCheck()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseButton.GetComponent<Image>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseButton.GetComponent<Image>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
