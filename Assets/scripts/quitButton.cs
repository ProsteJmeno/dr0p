using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{
    public GameObject toDisable;
    public GameObject box;

    private void Awake()
    {
        box.SetActive(false);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
    }

    public void quitClick()
    {
        toDisable.SetActive(false);
        box.SetActive(true);
    }

    public void nope()
    {
        box.SetActive(false);
        toDisable.SetActive(true);
    }
}
