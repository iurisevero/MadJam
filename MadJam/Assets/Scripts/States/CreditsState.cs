using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsState : BaseState
{
    protected override void Awake(){
        base.Awake();
    }

    public override void Enter(){
        base.Enter();
        audioController.Play("creditos");
        statusController.Hide();
        StartCoroutine(ShowCredits());
    }

    public override void Exit(){
        audioController.Stop("creditos");
        statusController.Show();
        base.Exit();
    }

    protected override void AddListeners(){
        base.AddListeners();
    }

    protected override void RemoveListeners(){
        base.RemoveListeners();
    }

    IEnumerator ShowCredits(){
        List<string> titles = new List<string>(){
            "Desing dos Personagens",
            "Cenário",
            "Desenvolvimento do Jogo",
            "Roteiro",
            "Som",
            "Projeto do Jogo",
        };

        List<List<string>> authors = new List<List<string>>();
        authors.Add(new List<string>(){ "Kaio Henrique Santos" });
        authors.Add(new List<string>(){ "João Pedro Eloi" });
        authors.Add(new List<string>(){ "Iuri Severo" });
        authors.Add(new List<string>(){ "Beatriz Reis", "Júlia Pascual" });
        authors.Add(new List<string>(){ "Iuri Severo", "João Pedro Eloi" });
        authors.Add(new List<string>(){
            "Beatriz Reis",
            "Iuri Severo",
            "João Pedro Eloi",
            "Júlia Pascual",
            "Kaio Henrique Santos"
        });

        creditsController.Display(titles, authors);
        yield return new WaitUntil(() => creditsController.finish );
        owner.ChangeState<MenuState>();
    }
}
