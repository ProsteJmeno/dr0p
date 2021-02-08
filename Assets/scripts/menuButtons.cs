using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtons : MonoBehaviour
{
    public Animator textAnimator;
    public Animator button1Animator;
    public Animator button2Animator;
    public Animator button3Animator;
    public Animator animationController;

    public void onPlayButtonClick()
    {
        textAnimator.SetBool("gameStart", true);
        button1Animator.SetBool("gameStart", true);
        button2Animator.SetBool("gameStart", true);
        button3Animator.SetBool("gameStart", true);
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
        textAnimator.SetBool("gameStart", false);
        button1Animator.SetBool("gameStart", false);
        button2Animator.SetBool("gameStart", false);
        button3Animator.SetBool("gameStart", false);
        SceneManager.LoadScene("gameplay");
    }
}
