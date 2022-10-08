using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData : ScriptableObject
{
    public Sprite sprite;
    public ConversationData conversationData;
    public Status statusInfluence;
    public int valueInfluence;
    public string title;
    public string description;
}
