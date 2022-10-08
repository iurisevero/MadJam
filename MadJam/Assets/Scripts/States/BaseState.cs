using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : State
{
    protected readonly Vector3 cameraCenterPosition = new Vector3(4.25f, 0.25f, 4.25f);
    protected const int minZoom = 1;
    protected const int maxZoom = 5;
    protected const float maxDistance = 5f;
    protected Controller owner;
    public ConversationController conversationController { get { return owner.conversationController; }}

    protected virtual void Awake(){
        owner = GetComponent<Controller>();
    }

    protected override void AddListeners(){
        this.AddObserver(OnFire, InputController.FireNotification);
    }

    protected override void RemoveListeners(){
        this.RemoveObserver(OnFire, InputController.FireNotification);
    }

    protected virtual void OnFire(object sender, object args){
        
    }

    public override void Enter(){
        base.Enter();
    }
}
