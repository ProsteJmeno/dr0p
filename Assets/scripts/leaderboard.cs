using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderboard : MonoBehaviour
{
    public static leaderboard instance;

    private void Awake()
    {
        TestSingleton();
    }

    private void TestSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderboard(int score)
    {
        // Leaderboards.Highscore.SubmitScore(score);
    }

}
