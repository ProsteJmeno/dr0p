using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public static bool isRunning = false;
    public float timeStart = 5;
    Text textbox;
    void Start()
    {
        textbox = GetComponent<Text>();
        textbox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timeStart >= 0)
            {
                timeStart -= Time.deltaTime;
                textbox.text = Mathf.Round(timeStart).ToString();
            }
            else
            {
                playAgain();

            }
        }

    }
    void onTimeExpire()
    {

    }

    public void playAgain()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<collision>().PlayAgain();
    }
}
