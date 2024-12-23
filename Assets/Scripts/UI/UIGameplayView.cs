using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayView : UIView
{
    [SerializeField] Text aiHandTxt;
    [SerializeField] Image iconImg;
    [SerializeField] Text timerTxt;
    [SerializeField] Image timerFill;
    [SerializeField] Sprite defaultIcon;

    // public Image TimerFill => timerFill;

    void OnEnable() 
    {
        SetAIHandText ("AI Hand", null);

        RoundHandler.OnRoundStart += HandleRoundStart;
    }

    void OnDisable() 
    {
        RoundHandler.OnRoundStart -= HandleRoundStart;
    }

    void HandleRoundStart ()
    {
        timerFill.fillAmount = 1f;
    }

    public void SetTimer (float timeLeft, float roundDuration)
    {
        timerTxt.text = $"Timer: {Mathf.CeilToInt(timeLeft)}s";
        timerFill.fillAmount = timeLeft / roundDuration;
    }

    public void SetAIHandText (string text, Sprite icon)
    {
        aiHandTxt.text = text;
        iconImg.sprite = (icon == null) ? defaultIcon : icon;
    }
    
}
