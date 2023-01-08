using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(menuName = "ResourceManager")]

public class ResourceManager : ScriptableObject
{

    Dictionary<string, int> resources;

    [SerializeField] TriggeredEvent updateResourceUIEvent;

    [SerializeField] int startingGold;
    [SerializeField] int startingFood;
    [SerializeField] int startingDays;
    [SerializeField] int startingCrystal;
    [SerializeField] int startingShelter;
    [SerializeField] int startingStone;

    public void Init()
    {
        resources = new Dictionary<string, int>();
        resources.Add("gold", startingGold);
        resources.Add("goldIncome", 0);
        resources.Add("shelter", startingShelter);
        resources.Add("workers", 0);
        resources.Add("crystal", startingCrystal);
        resources.Add("crystalIncome", 0);
        resources.Add("food", startingFood);
        resources.Add("foodIncome", 0);
        resources.Add("foodUse", 0);
        resources.Add("stone", startingStone);
        resources.Add("stoneIncome", 0);
        resources.Add("days", startingDays);
        resources.Add("nothing", 0);

        updateResourceUIEvent.Trigger();
    }
    public int GetResource(string resource)
    {
        return resources[resource];
    }

    public void AddResource(string resource, int howMuch)
    {
        resources[resource] += howMuch;
        updateResourceUIEvent.Trigger();
    }

    public void AddYield(string resource, int howMuch)
    {
        switch (resource)
        {
            case "gold": resources["goldIncome"] += howMuch; break;
            case "stone": resources["stoneIncome"] += howMuch; break;
            case "crystal": resources["crystalIncome"] += howMuch; break;
            case "food": resources["foodIncome"] += howMuch; break;

        }
        updateResourceUIEvent.Trigger();
    }

    public void SpendResource(string resource, int howMuch)
    {
        resources[resource] = Mathf.Max(resources[resource] - howMuch, 0);
        updateResourceUIEvent.Trigger();

    }
}
