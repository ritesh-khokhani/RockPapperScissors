using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules
{
   public static readonly int[,] RulesMatrix = 
   {
        // Rock, Paper, Scissors, Lizard, Spock
        {  0,   -1,     1,        1,      -1 },  // Rock
        {  1,    0,    -1,       -1,       1 },  // Paper
        { -1,    1,     0,        1,      -1 },  // Scissors
        { -1,    1,    -1,        0,       1 },  // Lizard
        {  1,   -1,     1,       -1,       0 }   // Spock
    };

}

public enum HandType
{
    Rock = 0,
    Paper = 1,
    Scissors = 2,
    Lizard = 3,
    Spock = 4
}

public enum ResultType
{
    Win = 1,
    Lose = -1,
    Tie = 0
}

