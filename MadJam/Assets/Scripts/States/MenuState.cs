using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    protected override void Awake(){
        base.Awake();
    }

    public override void Enter(){
        base.Enter();
        statusController.Hide();
        menuController.Show();
    }

    public override void Exit(){
        base.Exit();
        menuController.Hide();
        statusController.Show();
    }

    protected override void AddListeners(){
        base.AddListeners();
        this.AddObserver(OnFire, InputController.FireNotification);
    }

    protected override void RemoveListeners(){
        base.RemoveListeners();
    }

    protected override void OnFire (object sender, object args){
		var info = args as Info<int>;
        base.OnFire (sender, info.arg0);
        Player.Instance.SetStatus(5, 5, 5, 5);
        Job.Instance.SetRandomStatus();
        Week.Instance.SetWeek();
        owner.statusController.UpdateStatusValue();
        owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["IntroScene"]);
        owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["TesteScene"]);
        owner.afterConversationState.Enqueue(States.CutScene);
        owner.afterConversationState.Enqueue(States.WorldChoice);
        owner.ChangeState<CutSceneState>();
	}
}
