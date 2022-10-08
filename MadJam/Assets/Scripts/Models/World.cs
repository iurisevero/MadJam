using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class World : ScriptableObject
{
    public Sprite sprite;
    public List<ConversationData> conversationData;
    public Status statusInfluence;
    public int valueInfluence;
}
