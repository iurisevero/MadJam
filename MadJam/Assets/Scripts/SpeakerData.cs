using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeakerData
{
    public List<string> messages;
    public List<Sprite> speaker;
    public bool leftPanel;
    // public override string ToString(){
    //     string ret = "Messages:\n";
    //     foreach(string s in messages){
    //         ret += s + "\n";
    //     }
    //     ret += "Speaker: " + speaker.name + "\n";
    //     ret += "TextAnchor: " + ((char)anchor) + "\n";
    //     return ret;
    // }
}
