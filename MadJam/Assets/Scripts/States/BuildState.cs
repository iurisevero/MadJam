using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : BaseState
{
    protected override void Awake(){
        base.Awake();
    }

    public override void Enter(){
        base.Enter();
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

    // protected override void OnFire (object sender, object args){
	// 	var info = args as Info<int>;
    //     base.OnFire (sender, info.arg0);
	// 	conversationController.Next();
    //     owner.ChangeState<CutSceneState>();
	// }
}
