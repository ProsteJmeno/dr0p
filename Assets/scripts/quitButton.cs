using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{
    public GameObject canvasContent;
    public GameObject box;
    public GameObject credit;

    private void Awake()
    {
        box.SetActive(false);
        credit.SetActive(false);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
    }

    public void quitClick()
    {
        canvasContent.SetActive(false);
        box.SetActive(true);
    }

    public void nope()
    {
        box.SetActive(false);
        canvasContent.SetActive(true);
    }

    public void CreditOn()
    {
        canvasContent.SetActive(false);
        credit.SetActive(true);
    }

    public void CreditOff()
    {
        credit.SetActive(false);
        canvasContent.SetActive(true);
    }
}
