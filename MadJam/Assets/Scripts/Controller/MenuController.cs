using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    const string ShowKey = "Show";
    const string HideKey = "Hide";
    public Panel panel;
    public float timer = 0;
    public TextMeshProUGUI pressStart;

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer >= 0.5){
                pressStart.enabled = true;
        }
        if(timer >= 1){
                pressStart.enabled = false;
                timer = 0;
        }
    }

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
