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

    public void Init()
    {
        resources = new Dictionary<string, int>();
        resources.Add("gold", startingGold);
        resources.Add("goldIncome", 0);
        resources.Add("shelter", 0);
        resources.Add("workers", 0);
        resources.Add("crystal", startingCrystal);
        resources.Add("food", startingFood);
        resources.Add("foodIncome", 0);
        resources.Add("foodUse", 0);
        resources.Add("stone", 0);
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

    public void SpendResource(string resource, int howMuch)
    {
        resources[resource] = Mathf.Max(resources[resource] - howMuch, 0);
        updateResourceUIEvent.Trigger();

    }
}
