using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtons : MonoBehaviour
{
    public Animator animationController;

    public GameObject canvasContent;
    Image[] images;
    Text[] texts;

    private void Start()
    {
        images = canvasContent.GetComponentsInChildren<Image>();
        texts = canvasContent.GetComponentsInChildren<Text>();

        foreach (Image o in images)
        {
            o.canvasRenderer.SetAlpha(1);
        }
        foreach (Text o in texts)
        {
            o.canvasRenderer.SetAlpha(1);
        }
    }

    public void onPlayButtonClick()
    {
        images = canvasContent.GetComponentsInChildren<Image>();
        texts = canvasContent.GetComponentsInChildren<Text>();
        foreach (Image o in images)
        {
            o.CrossFadeAlpha(0, 1, false);
            print(o.gameObject.name);
        }
        foreach (Text o in texts)
        {
            o.CrossFadeAlpha(0, 1, false);
        }
        //gameObject.GetComponent<Image>().CrossFadeAlpha(0, 1, false);
        StartCoroutine(startAnimation());
    }

    public void onSettingsButtonClick()
    {
        SceneManager.LoadScene("settings");
    }


    private IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(1);
        animationController.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("gameplay");
    }
}
