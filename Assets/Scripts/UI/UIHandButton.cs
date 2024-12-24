using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandButton : MonoBehaviour
{
    [SerializeField] Button handButton;
    [SerializeField] Text handTxt;
    [SerializeField] Image handIcon;

    Hand hand;
    
    void Start()
    {
        handButton.onClick.AddListener (OnHandlSelected);
    }

    public void SetHand (Hand hand)
    {
        this.hand = hand;

        handTxt.text = hand.HandName;
        handIcon.sprite = hand.Icon;
    }

    void OnHandlSelected ()
    {
        RoundHandler.Instance.SelectHand (hand);
    }
   
}
