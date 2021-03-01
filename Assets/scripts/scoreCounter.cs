using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{

    bool wasTriggered = false;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (transform.position.y < player.transform.position.y /*- (player.transform.localScale.y/2)*/)
            {
                scoreCount();
                wasTriggered = true;
            }
        }
    }

    void scoreCount()
    {
        if (!wasTriggered)
        {

            if (PlayerPrefs.HasKey("score"))
            {
                var score = PlayerPrefs.GetInt("score");
                score++;
                PlayerPrefs.SetInt("score", score);
            }

            else
            {
                PlayerPrefs.SetInt("score", 1);
            }
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
    }
}
