using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChoiceState : BaseState
{
    protected override void Awake(){
        base.Awake();
        audioController.Play("selecaoDosMundos");
        audioController.Pause("selecaoDosMundos");
    }

    public override void Enter(){
        base.Enter();
        audioController.UnPause("selecaoDosMundos");
        StartCoroutine(PopulateWorld());
    }

    public override void Exit(){
        base.Exit();
        audioController.Pause("selecaoDosMundos");
        worldChoiceController.Hide();
    }

    protected override void AddListeners(){
        base.AddListeners();
    }

    protected override void RemoveListeners(){
        base.RemoveListeners();
    }

    public IEnumerator PopulateWorld(){
        yield return new WaitForEndOfFrame();
        int dayCount = Week.Instance.dayCount++;
        if(dayCount >= 3){
            bool status1 = CheckStatus(Job.Instance.mainStatus[0], Job.Instance.status1Value);
            bool status2 = CheckStatus(Job.Instance.mainStatus[1], Job.Instance.status2Value);
            owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["Cemiterio2"]);
            owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["DiaSeguinte"]);
            if(status1 && status2)
                owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["Vitoria"]);
            else
                owner.toPlayConversation.Enqueue(ConversationLoader.Instance.conversations["Derrota"]);
            owner.afterConversationState.Enqueue(States.CutScene);
            owner.afterConversationState.Enqueue(States.CutScene);
            owner.afterConversationState.Enqueue(States.Credits);
            owner.ChangeState<CutSceneState>();
        } else {
            List<WorldData> worlds = Week.Instance.week[dayCount];

            worldChoiceController.leftWorld.Display(worlds[0]);
            worldChoiceController.leftWorld.button.onClick.RemoveAllListeners();
            worldChoiceController.leftWorld.button.onClick.AddListener(
                delegate { WorldOnClick(
                    worlds[0].conversationData,
                    worlds[0].statusInfluence,
                    worlds[0].valueInfluence
                ); 
            });

            worldChoiceController.centerWorld.Display(worlds[1]);
            worldChoiceController.centerWorld.button.onClick.RemoveAllListeners();
            worldChoiceController.centerWorld.button.onClick.AddListener(
                delegate { WorldOnClick(
                    worlds[1].conversationData,
                    worlds[1].statusInfluence,
                    worlds[1].valueInfluence
                ); 
            });

            worldChoiceController.rightWorld.Display(worlds[2]);
            worldChoiceController.rightWorld.button.onClick.RemoveAllListeners();
            worldChoiceController.rightWorld.button.onClick.AddListener(
                delegate { WorldOnClick(
                    worlds[2].conversationData,
                    worlds[2].statusInfluence,
                    worlds[2].valueInfluence
                ); 
            });

            owner.afterConversationState.Enqueue(States.WorldChoice);
            worldChoiceController.Show();
        }
    }

    public void WorldOnClick(ConversationData conversationData, Status status, int value){
        owner.toPlayConversation.Enqueue(conversationData);
        Player.Instance.IncrementStatus(status, value);
        statusController.UpdateStatusValue();
        audioController.Play("portalFX");
        owner.ChangeState<CutSceneState>();
    }

    public bool CheckStatus(Status status, int value){
        int playerValue = 0;
        switch (status)
        {
            case Status.Confidence:
                playerValue = Player.Instance.confidence;
                break;
            case Status.Creativity:
                playerValue = Player.Instance.creativity;
                break;
            case Status.Organization:
                playerValue = Player.Instance.organization;
                break;
            case Status.Sociability:
                playerValue = Player.Instance.sociability;
                break;
            default:
                playerValue = 0;
                break;
        }
        return playerValue >= value;
    }
}
