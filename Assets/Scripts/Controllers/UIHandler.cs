using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : Singleton<UIHandler>
{
    [SerializeField] List<UIView> views;

    // public UIGameplayView gameplayView { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        // gameplayView = (UIGameplayView)GetView (ViewType.Gameplay);
    }

    public void ShowView (ViewType viewType)
    {
        views.ForEach (v => v.Hide ());
        UIView view = views.Find (v => v.viewType == viewType);
        view?.Show ();
    }

    public UIView GetView (ViewType viewType)
    {
        return views.Find (v => v.viewType == viewType);
    }
   
}

public enum ViewType
{
    Menu,
    Gameplay,
    Result
}
