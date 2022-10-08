using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    const string _Show = "Show";
    const string _Hide = "Hide";

    [SerializeField] Image background;
    [SerializeField] ConversationPanel leftPanel;
    [SerializeField] ConversationPanel rightPanel;
    Canvas canvas;
    IEnumerator conversation;
    Tweener transition;

    public static event EventHandler completeEvent;

    void Start(){
        canvas = GetComponentInChildren<Canvas>();
        if(leftPanel.panel.CurrentPosition == null)
            leftPanel.panel.SetPosition(_Hide, false);
        if(rightPanel.panel.CurrentPosition == null)
            rightPanel.panel.SetPosition(_Hide, false);
        canvas.gameObject.SetActive(false);
    }

    IEnumerator Sequence(ConversationData data){
        background.sprite = data.background;
        for(int i = 0; i < data.list.Count; ++i){
            SpeakerData sd = data.list[i];
            ConversationPanel currentPanel = (sd.leftPanel? leftPanel : rightPanel);
            IEnumerator presenter = currentPanel.Display(sd);
            presenter.MoveNext();

            currentPanel.panel.SetPosition(_Hide, false);
            MovePanel(currentPanel, _Show);

            yield return null;
            while (presenter.MoveNext())
                yield return null;

            MovePanel(currentPanel, _Hide);
            transition.completedEvent += delegate(object sender, EventArgs e) {
                conversation.MoveNext();
            };

            yield return null;
        }

        canvas.gameObject.SetActive(false);
        if (completeEvent != null)
            completeEvent(this, EventArgs.Empty);
    }

    void MovePanel(ConversationPanel obj, string pos){
        transition = obj.panel.SetPosition(pos, true);
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
