using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHolder : MonoBehaviour
{
    public Text holder;

    void Update()
    {
        int score;
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }

        else score = 0;

        holder.text = ("Score: " + score);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("score");
    }
}
