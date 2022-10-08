using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : Singleton<Job>
{
    public List<Status> mainStatus;
    public int status1Value;
    public int status2Value;
    
    public void SetRandomStatus(){
        mainStatus = new List<Status>(){
            Status.Confidence,
            Status.Creativity,
            Status.Organization,
            Status.Sociability
        };
        mainStatus.RemoveAt(Random.Range(0, mainStatus.Count));
        mainStatus.RemoveAt(Random.Range(0, mainStatus.Count));

        status1Value = Random.Range(0, 5);
        status2Value = Random.Range(0, 5);
    }
}
