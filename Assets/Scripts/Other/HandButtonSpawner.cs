using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandButtonSpawner : Singleton <HandButtonSpawner>
{
    [SerializeField] RulesData rulesData;
    [SerializeField] GameObject handButtonPrefab;

    public List<UIHandButton> SpawnHandButtons(Transform buttonParent)
    {
        List<UIHandButton> handButtons = new List<UIHandButton>();
        foreach (Hand hand in rulesData.Hands)
        {
            GameObject buttonObj = Instantiate(handButtonPrefab, buttonParent);

            UIHandButton handButton = buttonObj.GetComponent<UIHandButton>();
            handButton.SetHand(hand);
            handButtons.Add (handButton);
        }
        return handButtons;
    }
}
