using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneState : BaseState
{
    ConversationData data;

    protected override void Awake(){
        base.Awake();
    }

    public override void Enter(){
        base.Enter();
        data = owner.toPlayConversation.Dequeue();
        audioController.Play(data.background.name);
        conversationController.Show(data);
    }

    public override void Exit(){
        base.Exit();
        audioController.Stop(data.background.name);
    }

    protected override void AddListeners(){
        base.AddListeners();
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
        owner.ChangeState<HelperState>();
    }

    IEnumerator NoConversationData(){
        yield return null;
        OnCompleteConversation(this, System.EventArgs.Empty);
    }
}
