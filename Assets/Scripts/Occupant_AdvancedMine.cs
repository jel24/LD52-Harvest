using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Occupant_AdvancedMine : Occupant_Mine
{

    void Start()
    {
        int[] index = hex.GetHexIndex();
        Hex[] hexes = hexManager.GetAdjacentHexes(index[0], index[1]);
        for (int i = 0; i < 6; i++)
        {
            hexes[i].IncreaseLightness(lightIncrease);
            hexes[i].AddYield();
        }
    }

    public override void OnMine()
    {
        int[] index = hex.GetHexIndex();
        Hex[] hexes = hexManager.GetAdjacentHexes(index[0], index[1]);
        for (int i = 0; i < 6; i++)
        {
            hexes[i].Mine();
            hexes[i].Mine();

        }
    }
}
