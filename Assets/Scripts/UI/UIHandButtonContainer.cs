using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandButtonContainer : MonoBehaviour
{
    [SerializeField] Transform buttonParent;

    List<UIHandButton> handButtons;

    void OnEnable() 
    {
        SpawnHomeButtons ();
    }

    void SpawnHomeButtons ()
    {
        if (handButtons == null)
        {
            handButtons = HandButtonSpawner.Instance.SpawnHandButtons (buttonParent);
        }
    }
}
