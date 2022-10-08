using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public int confidence;
    public int creativity;
    public int organization;
    public int sociability;

    public void SetStatus(int confidence, int creativity, int organization, int sociability){
        this.confidence = confidence;
        this.creativity = creativity;
        this.organization = organization;
        this.sociability = sociability;
    }

    public void IncrementStatus(Status status, int value){
        switch (status)
        {
            case Status.Confidence:
                this.confidence+=value;
                break;
            case Status.Creativity:
                this.creativity+=value;
                break;
            case Status.Organization:
                this.organization+=value;
                break;
            case Status.Sociability:
                this.sociability+=value;
                break;
            default:
                Debug.Log("Status inválido");
                break;
        }
    }
}
