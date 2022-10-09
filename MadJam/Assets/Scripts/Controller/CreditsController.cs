using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsController : MonoBehaviour
{
    [SerializeField] GameObject textBackground;
    [SerializeField] CanvasGroup groupBackground;
    [SerializeField] GameObject authorObj;
    [SerializeField] CanvasGroup groupAuthor;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI author;
    public bool finish = false;
    EasingControl easingControlTitle;
    EasingControl easingControlAuthor;

    void Awake(){
        easingControlTitle = textBackground.AddComponent<EasingControl>();
        easingControlTitle.equation = EasingEquations.EaseInOutQuad;
        easingControlTitle.endBehaviour = EasingControl.EndBehaviour.Constant;
        easingControlTitle.updateEvent += OnUpdateEventTitle;

        easingControlAuthor = authorObj.AddComponent<EasingControl>();
        easingControlAuthor.equation = EasingEquations.EaseInOutQuad;
        easingControlAuthor.endBehaviour = EasingControl.EndBehaviour.Constant;
        easingControlAuthor.updateEvent += OnUpdateEventAuthor;

        textBackground.SetActive(false);
        authorObj.SetActive(false);
    }

    public void Display(List<string> titles, List<List<string>> authors){   
        finish = false;     
        StartCoroutine(Sequence(titles, authors));
    }

    void OnUpdateEventTitle(object sender, EventArgs e){
        Debug.Log("easingControlTitle.currentValue: " + easingControlTitle.currentValue);
        groupBackground.alpha = easingControlTitle.currentValue;
    }

    void OnUpdateEventAuthor(object sender, EventArgs e){
        Debug.Log("easingControlAuthor.currentValue: " + easingControlAuthor.currentValue);
        groupAuthor.alpha = easingControlAuthor.currentValue;
    }

    IEnumerator Sequence(List<string> titles, List<List<string>> authors){
        for(int i=0; i < titles.Count; ++i){
            groupBackground.alpha = 0;
            textBackground.SetActive(true);
            this.title.text = titles[i];

            easingControlTitle.Play();

            while(easingControlTitle.IsPlaying)
                yield return null;

            yield return StartCoroutine(SequenceAuthor(authors[i]));

            easingControlTitle.duration = 0.5f;
            easingControlTitle.Reverse();

            while(easingControlTitle.IsPlaying)
                yield return null;
            
            textBackground.SetActive(false);
        }
        finish = true;
    }

    IEnumerator SequenceAuthor(List<string> authors){
        foreach(string author in authors){
            groupAuthor.alpha = 0;
            authorObj.SetActive(true);
            this.author.text = author;
            easingControlAuthor.Play();

            while(easingControlAuthor.IsPlaying)
                yield return null;
            
            yield return new WaitForSeconds(1.0f);

            easingControlAuthor.duration = 0.5f;
            easingControlAuthor.Reverse();

            while(easingControlAuthor.IsPlaying)
                yield return null;
            
            authorObj.SetActive(false);
        }
    }
}
