using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : Singleton <TimerManager>
{
    public static event Action OnTimerComplete;
    IEnumerator timerCoroutine;

    public void StartTimer(float roundDuration, Action<float> onUpdate = null)
    {
        timerCoroutine = TimerCoroutine(roundDuration, onUpdate);
        StartCoroutine (timerCoroutine);
    }
    public void StopTimer ()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    IEnumerator TimerCoroutine(float roundDuration, Action<float> onUpdate = null)
    {
        float timeLeft = roundDuration;
        while (timeLeft > 0f)       // while (timeLeft > 0f && isRoundActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0f) 
                timeLeft = 0f;

            onUpdate?.Invoke(timeLeft);
            
            yield return null;
        }

        OnTimerComplete?.Invoke();
    }

}
