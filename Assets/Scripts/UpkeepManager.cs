using System.Collections;
using System.Collections.Generic;
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

            Occupant_Mine[] mines = FindObjectsOfType<Occupant_Mine>();
            Queue<Occupant_Mine> minesList = new Queue<Occupant_Mine>();


            for (int i = 0; i < mines.Length; i++)
            {
                minesList.Enqueue(mines[i]);
            }


            while (shortfall < 0)
            {
                Occupant_Mine mineToDestroy = minesList.Dequeue();
                mineToDestroy.hex.ClearOccupant();
                mineToDestroy.CleanUp();
                resourceManager.SpendResource("workers", 2);
                shortfall += 4;
            }

        } else
        {
            resourceManager.SpendResource("food", 2 * workers);
        }



    }


    public void CheckShelter()
    {
        Occupant_Mine[] mines = FindObjectsOfType<Occupant_Mine>();
        Queue<Occupant_Mine> minesList = new Queue<Occupant_Mine>();

        for (int i = 0; i < mines.Length; i++)
        {
            minesList.Enqueue(mines[i]);
        }


        while (resourceManager.GetResource("shelter") < resourceManager.GetResource("workers"))
        {
            Occupant_Mine mineToDestroy = minesList.Dequeue();
            mineToDestroy.hex.ClearOccupant();
            mineToDestroy.CleanUp();
            resourceManager.SpendResource("workers", 2);
            abandonShelter.Trigger();
        }


    }
}
