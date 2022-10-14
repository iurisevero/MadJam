using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusController : MonoBehaviour
{
    const string ShowKey = "Show";
    const string HideKey = "Hide";
    public Panel panel;
    public TextMeshProUGUI confidenceTitle, creativityTitle, organizationTitle, sociabilityTitle;
    public TextMeshProUGUI confidenceValue, creativityValue, organizationValue, sociabilityValue;

    public void UpdateStatusValue(){
        Player p = Player.Instance;
        confidenceValue.text = p.confidence.ToString();
        creativityValue.text = p.creativity.ToString();
        organizationValue.text = p.organization.ToString();
        sociabilityValue.text = p.sociability.ToString();
    }

    public void SetMainStatus(Status mainStatus, Status secondaryStatus){
        confidenceTitle.fontStyle = creativityTitle.fontStyle = 
        organizationTitle.fontStyle = sociabilityTitle.fontStyle = FontStyles.Bold;
        
        if(mainStatus == Status.Confidence || secondaryStatus == Status.Confidence)
            confidenceTitle.fontStyle |= FontStyles.Underline;
        if(mainStatus == Status.Creativity || secondaryStatus == Status.Creativity)
            creativityTitle.fontStyle |= FontStyles.Underline;
        if(mainStatus == Status.Organization || secondaryStatus == Status.Organization)
            organizationTitle.fontStyle |= FontStyles.Underline;
        if(mainStatus == Status.Sociability || secondaryStatus == Status.Sociability)
            sociabilityTitle.fontStyle |= FontStyles.Underline;
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
