using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuView : UIView
{

    [SerializeField] InputField roundDuration;

    void OnEnable ()
    {
        roundDuration.text = $"{RoundHandler.Instance.RoundDuration}";
    }

    public void OnClickPlay ()
    {
        UIHandler.Instance.ShowView (ViewType.Gameplay);
        GameManager.Instance.StartGame ();
    }

    public void OnClickSetRoundDuration ()
    {
        string value = roundDuration.text;
        if (int.TryParse (value, out int parsedValue))
        {
            RoundHandler.Instance.RoundDuration = parsedValue;
        }
    }
}
