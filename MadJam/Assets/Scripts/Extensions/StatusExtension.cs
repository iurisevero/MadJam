using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatusExtension
{
    public static string ToCustomString(this Status status){
        switch (status)
        {
            case Status.Confidence:
                return "CONFIANÇA";
            case Status.Creativity:
                return "CRIATIVIDADE";
            case Status.Organization:
                return "ORGANIZAÇÃO";
            case Status.Sociability:
                return "SOCIABILIDADE";
            default:
                return "";
        }
    }
}
