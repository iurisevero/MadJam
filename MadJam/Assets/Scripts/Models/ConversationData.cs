using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConversationData : ScriptableObject
{
    public List<SpeakerData> list;
    public Sprite background;
}
