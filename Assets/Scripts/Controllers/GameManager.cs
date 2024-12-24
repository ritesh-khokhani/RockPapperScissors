using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton <GameManager>
{

    int currentScore = 0;

    const string PREF_HIGH_SCORE = "HighScore";

    void Start()
    {
        ShowMainMenu();

        RoundHandler.OnRoundEnd += HandleRoundEnd;
    }

    void OnDestroy()
    {
        RoundHandler.OnRoundEnd -= HandleRoundEnd;
    }

    public void StartGame()
    {
        currentScore = 0;

        RoundHandler.Instance.StartRound();
    }

    void HandleRoundEnd(ResultType result, Hand playerHand, Hand aiHand)
    {
        switch(result)
        {
            case ResultType.Win:
                currentScore++;
                RoundHandler.Instance.StartRound();
                break;

            case ResultType.Lose:
                EndGame();
                break;

            case ResultType.Tie:
                // EndGame();
                RoundHandler.Instance.StartRound();
                break;
        }
    }

    void EndGame()
    {
        if (currentScore > GetHighScore ())
        {
            SaveHighScore(currentScore);
        }

        ShowResult ();
    }
    
    void ShowMainMenu()
    {
        UIHandler.Instance.ShowView (ViewType.Menu);
    }

    void ShowResult ()
    {
        UIHandler.Instance.ShowView (ViewType.Result);
    }

    #region  SCORE_SYSTEM
    void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(PREF_HIGH_SCORE, score);
        PlayerPrefs.Save();
    }
    public int GetCurrentScore() => currentScore;
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(PREF_HIGH_SCORE, 0);
    }
    #endregion
    
}
