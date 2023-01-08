using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpkeepManager : MonoBehaviour
{

    [SerializeField] ResourceManager resourceManager;
    [SerializeField] TriggeredEvent abandonShelter;
    [SerializeField] TriggeredEvent abandonFood;

    public void KingsBoon()
    {
        resourceManager.AddResource("food", 20);
        resourceManager.AddResource("gold", 100);

    }

    public void WorkersBoon()
    {
        resourceManager.AddResource("food", 10);
        resourceManager.AddResource("crystal", 5);
        resourceManager.AddResource("gold", 25);
        resourceManager.AddResource("shelter", 10);

    }

    public void TechnologistsBoon()
    {
        resourceManager.AddResource("crystal", 10);
    }

    public void CheckFood()
    {
        int food = resourceManager.GetResource("food");
        int workers = resourceManager.GetResource("workers");

        int shortfall = (food - 2 * workers);

        if (shortfall < 0)
        {
            abandonFood.Trigger();
            resourceManager.SpendResource("food", 9999);


            while (shortfall < 0)
            {
                Occupant_Mine mineToDestroy = FindObjectOfType<Occupant_Mine>();
                mineToDestroy.hex.ClearOccupant();
                mineToDestroy.CleanUp();
                resourceManager.SpendResource("workers", 2);
                resourceManager.AddResource("foodIncome", 4);
                shortfall += 2;
            }

        } else
        {
            resourceManager.SpendResource("food", 2 * workers);
        }



    }


    public void CheckShelter()
    {
        while (resourceManager.GetResource("shelter") < resourceManager.GetResource("workers"))
        {
            Occupant_Mine mineToDestroy = FindObjectOfType<Occupant_Mine>();
            mineToDestroy.hex.ClearOccupant();
            mineToDestroy.CleanUp();
            resourceManager.SpendResource("workers", 2);
            abandonShelter.Trigger();
        }


    }
}
