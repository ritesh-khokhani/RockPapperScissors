using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoundHandler : Singleton <RoundHandler>
{
    bool isRoundActive = false;
    HandType playerHand;
    UIGameplayView gameplayView;
    [SerializeField] Sprite []icons;
    internal float RoundDuration = 1f;
    const float END_DELAY = 1f;

    public static event Action OnRoundStart;
    public static event Action<ResultType, HandType, HandType> OnRoundEnd;

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

    public void SelectHand(HandType handType)
    {
        if (!isRoundActive) 
            return;

        TimerManager.Instance.StopTimer ();

        playerHand = handType;
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
        HandType aiHand = AIHandler.GetRandomHand();
        gameplayView.SetAIHandText (aiHand.ToString (), icons[(int)aiHand]);

        int resultValue = Rules.RulesMatrix[(int)playerHand, (int)aiHand];
        ResultType resultType = (ResultType)resultValue;

        NotifyRoundEnd(resultType, playerHand, aiHand);
    }

    void NotifyRoundEnd(ResultType result, HandType playerHand = HandType.Rock, HandType aiHand = HandType.Rock)
    {
        DOVirtual.DelayedCall (END_DELAY, ()=> {
           OnRoundEnd?.Invoke(result, playerHand, aiHand);
        });
    }
    
}
