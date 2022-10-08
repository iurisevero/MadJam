using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : StateMachine
{
    // public IEnumerator round;
    public ConversationController conversationController;

    void Start(){
        StartCoroutine(WaitAFrame());
    }

    IEnumerator WaitAFrame(){
        yield return new WaitForEndOfFrame();
        ChangeState<CutSceneState>();
    }
}
