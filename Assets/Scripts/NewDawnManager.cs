using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NewDawnManager")]

public class NewDawnManager : ScriptableObject
{

    public int[] timesTaken;
    
    [SerializeField] TriggeredEvent[] engineeringEvents;
    [SerializeField] TriggeredEvent[] peopleEvents;
    [SerializeField] TriggeredEvent boonEvent;
    [SerializeField] GameObject[] engineeringOriginals;
    [SerializeField] GameObject[] peopleOriginals;

    public void Init()
    {
        timesTaken = new int[] { 0, 0, 0 };
    }

    public TriggeredEvent[] GetEvents()
    {
        TriggeredEvent[] events = new TriggeredEvent[3];
        events[0] = boonEvent;
        events[1] = peopleEvents[timesTaken[1]];
        events[2] = engineeringEvents[timesTaken[2]];
        return events;
    }

    public void Increment(int which)
    {
        timesTaken[which]++;
    }

    public string GetDescription(int which)
    {
        if (which == 1)
        {
            return peopleOriginals[timesTaken[which]].GetComponent<Occupant>().description;
        } else if (which == 2)
        {
            return engineeringOriginals[timesTaken[which]].GetComponent<Occupant>().description;
        }
        return "";
    }

    public string GetTitle(int which)
    {
        if (which == 1)
        {
            return peopleOriginals[timesTaken[which]].GetComponent<Occupant>().occupantName;
        }
        else if (which == 2)
        {
            return engineeringOriginals[timesTaken[which]].GetComponent<Occupant>().occupantName;
        }
        return "";
    }

    public Sprite GetImage(int which)
    {
        if (which == 1)
        {
            return peopleOriginals[timesTaken[which]].GetComponent<Occupant>().icon;
        }
        else if (which == 2)
        {
            return engineeringOriginals[timesTaken[which]].GetComponent<Occupant>().icon;
        }
        return null;
    }


}
