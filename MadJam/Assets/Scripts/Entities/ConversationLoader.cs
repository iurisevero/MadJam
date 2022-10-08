using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationLoader : Singleton<ConversationLoader>
{   
    public Dictionary<string, ConversationData> conversations;
    void Start()
    {
        conversations = new Dictionary<string, ConversationData>();
        LoadConversations();
    }

    public void LoadConversations(){
        List<ConversationData> conversationDatas = new List<ConversationData>(Resources.LoadAll<ConversationData>("Conversations/"));
        foreach(ConversationData conversation in conversationDatas){
            conversations[conversation.name] = conversation;
        }
    }
}
