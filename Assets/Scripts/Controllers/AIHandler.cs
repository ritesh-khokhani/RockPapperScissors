using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : Singleton <AIHandler>
{
    [SerializeField] RulesData rulesData;

    public Hand GetRandomHand()
    {
        int randomIndex = Random.Range(0, rulesData.Hands.Count);
        return rulesData.Hands[randomIndex];
    }

    // public static HandType GetRandomHand ()
    // {
    //     int randomValue = Random.Range(0, Rules.RulesMatrix.GetLength(0));
    //     return (HandType)randomValue;
    // }
}
