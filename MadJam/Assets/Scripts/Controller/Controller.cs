using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : StateMachine
{
    // public IEnumerator round;
    public MenuController menuController;
    public ConversationController conversationController;
    public StatusController statusController;
    public WorldChoiceController worldChoiceController;
    public AudioController audioController;
    public CreditsController creditsController;
    public Queue<ConversationData> toPlayConversation;
    public Queue<States> afterConversationState;

    void Start(){
        toPlayConversation = new Queue<ConversationData>();
        afterConversationState = new Queue<States>();
        ChangeState<MenuState>();
    }
}
