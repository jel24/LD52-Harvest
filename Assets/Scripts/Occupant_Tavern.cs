using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Occupant_Tavern : Occupant
{
    [SerializeField] int lightIncrease;
    [SerializeField] int shelterIncrease;

    void Start()
    {
        int[] index = hex.GetHexIndex();
        Hex[] hexes = hexManager.GetAdjacentHexes(index[0], index[1]);
        for (int i = 0; i < 6; i++)
        {
            hexes[i].IncreaseLightness(lightIncrease);
        }
        hex.AddYield();
        resourceManager.AddResource("shelter", shelterIncrease);
    }

    public override void OnMine()
    {
        Mine();
    }

}
