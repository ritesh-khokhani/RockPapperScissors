using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandButton : MonoBehaviour
{
    [SerializeField] HandType hand;
    [SerializeField] Button handButton;
    [SerializeField] Text handTxt;

    void Start()
    {
        handTxt.text = $"{hand}";

        handButton.onClick.AddListener (OnHandlSelected);
    }

    void OnHandlSelected ()
    {
        RoundHandler.Instance.SelectHand (hand);
    }
   
}
