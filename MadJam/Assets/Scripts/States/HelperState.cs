using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperState : BaseState
{
    protected override void Awake(){
        base.Awake();
    }

    public override void Enter(){
        base.Enter();
        StartCoroutine(WaitAFrame());
    }

    IEnumerator WaitAFrame(){
        yield return new WaitForEndOfFrame();
        switch (owner.afterConversationState.Dequeue())
        {
            case States.Base:
                owner.ChangeState<BaseState>();
                break;
            case States.Build:
                owner.ChangeState<BuildState>();
                break;
            case States.CutScene:
                owner.ChangeState<CutSceneState>();
                break;
            case States.Helper:
                owner.ChangeState<HelperState>();
                break;
            case States.Menu:
                owner.ChangeState<MenuState>();
                break;
            default:
                owner.ChangeState<BaseState>();
                break;
        }
    }

    public override void Exit(){
        base.Exit();
    }

    protected override void AddListeners(){
        base.AddListeners();
    }

    protected override void RemoveListeners(){
        base.RemoveListeners();
    }
}
