using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    void Update()
    {
        Text score = GetComponent<Text>();
        if (PlayerPrefs.HasKey("score"))
        {
            score.text = "Score: " + PlayerPrefs.GetInt("score");
        }
        else
        {
            score.text = "Score: 0";
        }
    }

    
}
