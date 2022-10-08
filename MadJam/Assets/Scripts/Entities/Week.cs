using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week : Singleton<Week>
{
    public List<WorldData> confidenceWorlds;
    public List<WorldData> creativityWorlds;
    public List<WorldData> organizationWorlds;
    public List<WorldData> sociabilityWorlds;
    public WorldData etBilu;

    public int dayCount = 0;
    public List<List<WorldData>> week;

    public void SetWeek(){
        dayCount = 0;
        List<int> confidenceWorldIndex = new List<int>(FillIndex(confidenceWorlds.Count));
        List<int> creativityWorldIndex = new List<int>(FillIndex(creativityWorlds.Count));
        List<int> organizationWorldIndex = new List<int>(FillIndex(organizationWorlds.Count));
        List<int> sociabilityWorldIndex = new List<int>(FillIndex(sociabilityWorlds.Count));
        
        List<WorldData> day1 = new List<WorldData>();
        day1.Add(confidenceWorlds[GetRandomIndex(confidenceWorldIndex)]);
        day1.Add(organizationWorlds[GetRandomIndex(organizationWorldIndex)]);
        day1.Add(sociabilityWorlds[GetRandomIndex(sociabilityWorldIndex)]);
        day1.Shuffle();

        List<WorldData> day2 = new List<WorldData>();
        day2.Add(creativityWorlds[GetRandomIndex(creativityWorldIndex)]);
        day2.Add(organizationWorlds[GetRandomIndex(organizationWorldIndex)]);
        day2.Add(confidenceWorlds[GetRandomIndex(confidenceWorldIndex)]);
        day2.Shuffle();

        List<WorldData> day3 = new List<WorldData>();
        day3.Add(sociabilityWorlds[GetRandomIndex(sociabilityWorldIndex)]);
        day3.Add(etBilu);
        day3.Add(creativityWorlds[GetRandomIndex(creativityWorldIndex)]);
        day3.Shuffle();

        week = new List<List<WorldData>>();
        week.Add(day1);
        week.Add(day2);
        week.Add(day3);
    }

    public List<int> FillIndex(int size){
        List<int> worldIndex = new List<int>(size);
        for(int i=0; i < size; ++i)
            worldIndex.Add(i);
        return worldIndex;
    }

    public int GetRandomIndex(List<int> indexes){
        // string debug = "Indexes:";
        // foreach(int i in indexes)
        //     debug += " " + i.ToString();
        // Debug.Log(debug);
        int randIndex = Random.Range(0, indexes.Count);
        int ret = indexes[randIndex];
        indexes.RemoveAt(randIndex);
        return ret;
    }
}
