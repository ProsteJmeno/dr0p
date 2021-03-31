using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayServices : MonoBehaviour
{
    public int playerScore;
    string leaderboardID = "CgkIoJmE3YUXEAIQAA";


    void Start()
    {

        DontDestroyOnLoad(this);
        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool success) => { });
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        print("debug");
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
            print("leaderboard");
        }
        Social.ShowLeaderboardUI();
    }
}
