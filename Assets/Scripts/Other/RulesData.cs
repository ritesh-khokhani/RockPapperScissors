using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RulesData", menuName = "RockPaperScissors/RulesData")]
public class RulesData : ScriptableObject
{
    [SerializeField] List<Hand> hands;

    public List<Hand> Hands => hands;

    public ResultType GetResult(Hand playerHand, Hand aiHand)
    {
        if (playerHand == aiHand)
            return ResultType.Tie;

        return playerHand.Defeats.Contains(aiHand.HandType) ? ResultType.Win : ResultType.Lose;
    }
}

[Serializable]
public class Hand
{
    public HandType HandType;
    public string HandName;
    public Sprite Icon;
    public List<HandType> Defeats;
}
