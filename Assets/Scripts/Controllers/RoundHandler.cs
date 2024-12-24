using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoundHandler : Singleton <RoundHandler>
{
    bool isRoundActive = false;
    Hand playerHand;
    UIGameplayView gameplayView;
    [SerializeField] RulesData rulesData;

    internal float RoundDuration = 1f;
    const float END_DELAY = 1f;

    public static event Action OnRoundStart;
    public static event Action<ResultType, Hand, Hand> OnRoundEnd;

    void Start()
    {
        gameplayView = (UIGameplayView)UIHandler.Instance.GetView (ViewType.Gameplay);

        TimerManager.OnTimerComplete += HandleTimerComplete;
    }
    void OnDestroy ()
    {
        TimerManager.OnTimerComplete -= HandleTimerComplete;
    }

    public void StartRound()
    {
        OnRoundStart?.Invoke ();

        isRoundActive = true;
        gameplayView.SetTimer(RoundDuration, RoundDuration);

        TimerManager.Instance.StopTimer ();
        TimerManager.Instance.StartTimer (RoundDuration, (float timeLeft) => {
            gameplayView.SetTimer(timeLeft, RoundDuration);
        });
    }

    public void SelectHand(Hand hand)
    {
        if (!isRoundActive) 
            return;

        TimerManager.Instance.StopTimer ();

        playerHand = hand;
        isRoundActive = false;

        EvaluateRound();
    }

    void HandleTimerComplete()
    {
        if (!isRoundActive) 
            return;

        isRoundActive = false;
        NotifyRoundEnd(ResultType.Lose);
    }

    void EvaluateRound()
    {
        Hand aiHand = AIHandler.Instance.GetRandomHand();
        gameplayView.SetAIHandText(aiHand.HandName, aiHand.Icon);

        // int resultValue = Rules.RulesMatrix[(int)playerHand, (int)aiHand];
        ResultType result = rulesData.GetResult(playerHand, aiHand);
        // ResultType resultType = (ResultType)resultValue;

        NotifyRoundEnd(result, playerHand, aiHand);
    }

    void NotifyRoundEnd(ResultType result, Hand playerHand = null, Hand aiHand = null)
    {
        DOVirtual.DelayedCall (END_DELAY, ()=> {
           OnRoundEnd?.Invoke(result, playerHand, aiHand);
        });
    }
    
}
