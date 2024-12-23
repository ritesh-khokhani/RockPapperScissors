using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResultView : UIView
{
    [SerializeField] Text currScoreTxt, highScoreTxt;

    void OnEnable ()
    {
        currScoreTxt.text = $"Score: {GameManager.Instance.GetCurrentScore ()}";
        highScoreTxt.text = $"Best: {GameManager.Instance.GetHighScore ()}";
    }

    public void OnClickMainMenu ()
    {
        UIHandler.Instance.ShowView (ViewType.Menu);
    }
    
    public void OnClickRestart ()
    {
        UIHandler.Instance.ShowView (ViewType.Gameplay);
        GameManager.Instance.StartGame ();
    }
}
