using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler// : Singleton <AIHandler>
{
    public static HandType GetRandomHand ()
    {
        int randomValue = Random.Range(0, Rules.RulesMatrix.GetLength(0));
        return (HandType)randomValue;
    }
}
