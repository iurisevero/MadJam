using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusController : MonoBehaviour
{
    const string ShowKey = "Show";
    const string HideKey = "Hide";
    public Panel panel;
    public TextMeshProUGUI confidenceValue, creativityValue, organizationValue, sociabilityValue;

    public void UpdateStatusValue(){
        Player p = Player.Instance;
        confidenceValue.text = p.confidence.ToString();
        creativityValue.text = p.creativity.ToString();
        organizationValue.text = p.organization.ToString();
        sociabilityValue.text = p.sociability.ToString();
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
