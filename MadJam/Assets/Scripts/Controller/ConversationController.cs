using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    const string ShowKey = "Show";
    const string HideKey = "Hide";
    const string LeftKey = "Left";
    const string RightKey = "Right";

    [SerializeField] Image background;
    [SerializeField] Panel backgroundPanel;
    [SerializeField] ConversationPanel leftPanel;
    [SerializeField] ConversationPanel rightPanel;
    Canvas canvas;
    IEnumerator conversation;
    Tweener transition;

    public static event EventHandler completeEvent;

    void Start(){
        canvas = GetComponentInChildren<Canvas>();
        if(leftPanel.panel.CurrentPosition == null)
            leftPanel.panel.SetPosition(HideKey, false);
        if(rightPanel.panel.CurrentPosition == null)
            rightPanel.panel.SetPosition(HideKey, false);
        canvas.gameObject.SetActive(false);
    }

    IEnumerator Sequence(ConversationData data){
        background.sprite = data.background;
        Debug.Log("ConversationController dataCount: " + data.list.Count);
        for(int i = 0; i < data.list.Count; ++i){
            SpeakerData sd = data.list[i];
            ConversationPanel currentPanel = (sd.leftPanel? leftPanel : rightPanel);
            MovePanel(backgroundPanel, sd.leftPanel? LeftKey : RightKey);
            IEnumerator presenter = currentPanel.Display(sd);
            presenter.MoveNext();

            currentPanel.panel.SetPosition(HideKey, false);
            MovePanel(currentPanel, ShowKey);

            yield return null;
            while (presenter.MoveNext())
                yield return null;

            MovePanel(currentPanel, HideKey);
            transition.completedEvent += delegate(object sender, EventArgs e) {
                conversation.MoveNext();
            };

            yield return null;
        }
        Debug.Log("ConversationController after for");
        canvas.gameObject.SetActive(false);
        if (completeEvent != null)
            completeEvent(this, EventArgs.Empty);
    }

    void MovePanel(ConversationPanel obj, string pos){
        transition = obj.panel.SetPosition(pos, true);
        transition.duration = 0.5f;
        transition.equation = EasingEquations.EaseOutQuad;
    }

    void MovePanel(Panel panel, string pos){
        transition = panel.SetPosition(pos, true);
        transition.duration = 0.5f;
        transition.equation = EasingEquations.EaseOutQuad;
    }

    public void Show(ConversationData data){
        canvas.gameObject.SetActive(true);
        conversation = Sequence(data);
        conversation.MoveNext();
    }

    public void Next(){
        if(conversation == null || transition != null)
            return;
        
        conversation.MoveNext();
    }
}
