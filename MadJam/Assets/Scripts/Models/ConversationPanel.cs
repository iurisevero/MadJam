using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationPanel : MonoBehaviour
{
    public TextMeshProUGUI message;
    public Image speaker;
    public GameObject arrow;
    public GameObject talkPanel;
    public Panel panel;

    void Start()
    {
        Vector3 pos = arrow.transform.localPosition;
        arrow.transform.localPosition = new Vector3(pos.x, pos.y + 5, pos.z);
        Tweener t = arrow.transform.MoveToLocal(new Vector3(pos.x, pos.y - 5, pos.z), 0.5f, EasingEquations.EaseInQuad);
        t.loopType = EasingControl.LoopType.PingPong;
        t.loopCount = -1;
    }

    public IEnumerator Display(SpeakerData sd)
    {
        // speaker.SetNativeSize();

        for(int i = 0; i < sd.messages.Count; ++i)
        {
            speaker.sprite = sd.speaker[i];
            message.text = sd.messages[i];
            talkPanel.SetActive(!string.IsNullOrEmpty(message.text));
            arrow.SetActive(i + 1 < sd.messages.Count);
            yield return null;
        }
    }
}
