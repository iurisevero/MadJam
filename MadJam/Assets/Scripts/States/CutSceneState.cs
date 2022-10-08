using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneState : BaseState
{
    ConversationData data;

    protected override void Awake(){
        base.Awake();
        data = Resources.Load<ConversationData>("Conversations/IntroScene");
    }

    public override void Enter(){
        base.Enter();
        conversationController.Show(data);
    }

    public override void Exit(){
        base.Exit();
    }

    protected override void AddListeners(){
        this.AddObserver(OnFire, InputController.FireNotification);
        ConversationController.completeEvent += OnCompleteConversation;
    }

    protected override void RemoveListeners(){
        base.RemoveListeners();
        ConversationController.completeEvent -= OnCompleteConversation;
    }

    protected override void OnFire (object sender, object args){
		var info = args as Info<int>;
        base.OnFire (sender, info.arg0);
		conversationController.Next();
	}

    void OnCompleteConversation(object sender, System.EventArgs e){
        owner.ChangeState<CutSceneState>();
    }

    IEnumerator NoConversationData(){
        yield return null;
        OnCompleteConversation(this, System.EventArgs.Empty);
    }
}
