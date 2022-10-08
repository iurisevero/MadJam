using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldChoiceController : MonoBehaviour
{
    const string ShowKey = "Show";
    const string HideKey = "Hide";
    public Panel panel;

    public WorldPanel leftWorld;
    public WorldPanel rightWorld;
    public WorldPanel centerWorld;

    void TogglePos(string pos){
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 1f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    public void Show(){
        TogglePos(ShowKey);
    }

    public void Hide(){
        TogglePos(HideKey);
    }
}
