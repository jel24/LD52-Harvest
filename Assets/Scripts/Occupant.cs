using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occupant : MonoBehaviour
{
    public string occupantName;
    public string description;
    public Sprite icon;
    [SerializeField] protected ResourceManager resourceManager;
    [SerializeField] protected HexManager hexManager;
    public int goldCost;
    public int workerCost;
    public int crystalCost;
    public int stoneCost;
    public int lightRequirement;
    public string mineResource;
    public int mineValue;
    public int frequency = 2;
    public bool showAdjacentYield = false;

    public Hex hex;
    protected int counter = 0;

    public virtual void Action()
    {
    }

    public bool CanAfford()
    {
        return resourceManager.GetResource("gold") >= goldCost
            && resourceManager.GetResource("crystal") >= crystalCost
            && resourceManager.GetResource("stone") >= stoneCost;
    }

    public void Buy()
    {
        resourceManager.SpendResource("gold", goldCost);
        resourceManager.SpendResource("stone", stoneCost);
        resourceManager.SpendResource("crystal", crystalCost);
        resourceManager.AddResource("workers", workerCost);
        resourceManager.AddResource("foodIncome", -2 * workerCost);
    }

    public virtual void RightAction()
    {
        hex.ClearOccupant();
        Invoke("CleanUp", 1f);
    }

    public virtual void Increment()
    {
        counter++;
    }

    public virtual void OnMine()
    {

    }

    public void SetHex(Hex whichHex)
    {
        hex = whichHex;
    }

    public string GetName()
    {
        return occupantName;
    }

    public virtual int GetMineValue()
    {
        return mineValue;
    }

    public virtual string GetMineResource()
    {
        return mineResource;
    }

    public virtual void Mine()
    {
        if (counter % frequency == 0)
        {
            resourceManager.AddResource(GetMineResource(), GetMineValue());
        }
    }

    public void CleanUp()
    {
        Destroy(gameObject);
    }


}
