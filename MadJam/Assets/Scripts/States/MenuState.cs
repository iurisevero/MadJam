using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuState : BaseState
{
    protected override void Awake(){
        base.Awake();
    }

    public override void Enter(){
        base.Enter();
        audioController.Play("menu");
        statusController.Hide();
        menuController.Show();
    }

    public override void Exit(){
        base.Exit();
        audioController.Stop("menu");
        menuController.Hide();
        statusController.Show();
    }

    protected override void AddListeners(){
        base.AddListeners();
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
        SetMainStatus();
        owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["Intro"]);
        owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["Vazio"]);
        owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["Cemiterio"]);
        owner.afterConversationState.Enqueue(States.CutScene);
        owner.afterConversationState.Enqueue(States.CutScene);
        owner.afterConversationState.Enqueue(States.WorldChoice);
        owner.ChangeState<CutSceneState>();
	}

    public void SetMainStatus(){
        Status mainStatus = Job.Instance.mainStatus[0];
        Status secondaryStatus = Job.Instance.mainStatus[1];
        ConversationData intro = ConversationLoader.Instance.conversations["Intro"];
        intro.list[4].messages[1] = "Prioridade para\n" +
            $"{mainStatus.ToCustomString()} e {secondaryStatus.ToCustomString()}";
        statusController.SetMainStatus(mainStatus, secondaryStatus);
    }
}
